namespace StorageQueue.Helper.Services;

public class AzureQueueService : IAzureQueueService
{
    private readonly QueueClient _client;

    public AzureQueueService(QueueClient client)
    {
        _client = client;
    }
    
    public async Task CreateAsync() =>
        await _client.CreateIfNotExistsAsync();
    
    public async Task EnqueueMessageAsync(object message)
    {
        try
        {
            var messageSerialized = Message.SerializeToString(message);
            
            await _client.CreateIfNotExistsAsync();

            await _client.SendMessageAsync(messageSerialized);
        }
        catch (RequestFailedException ex)
        {
            Console.WriteLine(ex);
        }
    }
    
    public async Task<string?> DequeueMessageAsync()
    {
        var message = string.Empty;

        if (await CountMessages() > 0)
        {
            QueueMessage[] retrieveMessage = await _client.ReceiveMessagesAsync();

            if (retrieveMessage.Length > 0)
            {
                await _client.DeleteMessageAsync(retrieveMessage[0].MessageId, retrieveMessage[0].PopReceipt);

                message = retrieveMessage[0].MessageText;
            }
        }

        return message;
    }
    
    public async Task<List<string>> DequeueAllMessagesAsync()
    {
        var messages = new List<string>();

        while (await CountMessages() > 0)
        {
            QueueMessage[] retrieveMessage = await _client.ReceiveMessagesAsync();

            if (retrieveMessage.Length > 0)
            {
                await _client.DeleteMessageAsync(retrieveMessage[0].MessageId, retrieveMessage[0].PopReceipt);

                if (!string.IsNullOrWhiteSpace(retrieveMessage[0].MessageText))
                    messages.Add(retrieveMessage[0].MessageText);
            }
        }
        
        return messages;
    }
    
    public async Task<int?> CountMessages()
    {
        QueueProperties properties = await _client.GetPropertiesAsync();

        return properties.ApproximateMessagesCount;
    }

    public async Task ClearAsync() =>
        await _client.ClearMessagesAsync();
    
    public async Task DeleteAsync() =>
        await _client.DeleteIfExistsAsync();
}

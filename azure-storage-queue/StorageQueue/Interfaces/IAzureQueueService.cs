namespace StorageQueue.Helper.Interfaces;

public interface IAzureQueueService
{
    Task CreateAsync();
    Task EnqueueMessageAsync(object message);
    Task<string?> DequeueMessageAsync();
    Task<List<string>> DequeueAllMessagesAsync();
    Task<int?> CountMessages();
    Task ClearAsync();
    Task DeleteAsync();
}

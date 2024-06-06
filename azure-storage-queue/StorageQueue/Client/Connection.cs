namespace StorageQueue.Helper.Client;

public static class Connection
{
    public static QueueClient Connect(string connectionString, string queueName)
    {
        var configure = new Configure(connectionString);
        return configure.CreateConnection(queueName);
    }
}

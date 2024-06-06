namespace StorageQueue.Helper.Client;

internal class Configure
{
    private readonly string _connectionString;

    public Configure(string connectionString)
    {
        _connectionString = connectionString;
    }

    public QueueClient CreateConnection(string queueName) => 
        new (_connectionString, queueName);
}

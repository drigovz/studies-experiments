namespace Producer.Core.Interfaces.DatabaseConfig;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
}
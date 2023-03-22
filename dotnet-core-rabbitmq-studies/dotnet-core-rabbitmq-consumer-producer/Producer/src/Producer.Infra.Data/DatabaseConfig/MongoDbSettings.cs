using Producer.Core.Interfaces.DatabaseConfig;

namespace Producer.Infra.Data.DatabaseConfig;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}
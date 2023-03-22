namespace Microsoft.Extensions.Configuration;

public static class ConfigurationExtension
{
    public static string? GetRabbitMq(this IConfiguration configuration) =>
        configuration.GetConnectionString("RabbitMq");
}
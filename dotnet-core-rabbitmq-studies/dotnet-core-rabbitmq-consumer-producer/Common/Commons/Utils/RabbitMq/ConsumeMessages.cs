using Commons.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Commons;

public class ConsumeMessages : BackgroundService
{
    private readonly RabbitMqConfig _config;
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;

    public ConsumeMessages(IOptions<RabbitMqConfig> options, IConfiguration configuration)
    {
        _configuration = configuration;
        _config = options.Value;
        
        var connectionString = _configuration.GetConnectionString("RabbitMq");
        var factory = new ConnectionFactory
        {
            Uri = new Uri(connectionString)
        };
        
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        
        consumer.Received += PrintObject;
        
        _channel.BasicConsume(queue: _config.Queue,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    private static void PrintObject(object model, BasicDeliverEventArgs e)
    {
        var body = e.Body.ToArray();
        var message = body.ConvertToString();
        
        Console.WriteLine($" Received from [{e.Exchange}]:  \n{message}\n");
    }
}
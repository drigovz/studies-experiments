using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Commons;

public class ProduceMessage
{
    private readonly IConfiguration _configuration;

    public ProduceMessage(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Send(object message, string queueName, string exchangeName, string routingKey)
    {
        var connectionString = _configuration.GetRabbitMq();
        var factory = new ConnectionFactory
        {
            Uri = new Uri(connectionString)
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var byteMessage = message.ConvertToByteArray();

        // create queue
        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        // create exchange
        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);

        // bind queue with exchange 
        channel.QueueBind(queueName, exchangeName, routingKey);

        // publish message 
        channel.BasicPublish(
            exchange: exchangeName,
            routingKey: routingKey,
            basicProperties: null,
            body: byteMessage
        );
    }
}
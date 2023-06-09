﻿using Confluent.Kafka;
using Kafka.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Consumer
{
    public class KafkaConsumer<TKey, TValue> : IKafkaConsumer<TKey, TValue> where TValue : class
    {
        private readonly ConsumerConfig _config;
        private IKafkaHandler<TKey, TValue> _handler;
        private IConsumer<TKey, TValue> _consumer;
        private string _topic;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KafkaConsumer(ConsumerConfig config, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _config = config;
        }

        private async Task StartConsumerLoop(CancellationToken cancellationToken)
        {
            _consumer.Subscribe(_topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = _consumer.Consume(cancellationToken);
                    if (result != null)
                        await _handler.HandleAsync(result.Message.Key, result.Message.Value);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (ConsumeException ex)
                {
                    Console.WriteLine($"Consume error: {ex.Error.Reason}");

                    if (ex.Error.IsFatal)
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex}");
                    break;
                }
            }
        }

        public async Task Consume(string topic, CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            _handler = scope.ServiceProvider.GetRequiredService<IKafkaHandler<TKey, TValue>>();
            _consumer = new ConsumerBuilder<TKey, TValue>(_config).SetValueDeserializer(new KafkaDeserializer<TValue>()).Build();
            _topic = topic;

            await Task.Run(() => StartConsumerLoop(stoppingToken), stoppingToken);
        }

        public void Close()
        {
            _consumer.Close();
        }

        public void Dispose()
        {
            _consumer.Dispose();
        }
    }
}

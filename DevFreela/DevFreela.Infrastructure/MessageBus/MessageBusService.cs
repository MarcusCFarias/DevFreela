using DevFreela.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly IConnectionFactory _factory;

        public MessageBusService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }
        public void Publish(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: message);
                }
            }
        }
    }
}

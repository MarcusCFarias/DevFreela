using DevFreela.Application.IntegrationEvents;
using DevFreela.Application.Interfaces.Services;
using DevFreela.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Application.Consumers
{
    public class PaymentApprovedCosumer : BackgroundService
    {
        private const string QUEUE = "PaymentsApproved";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        public PaymentApprovedCosumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }



        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var paymentApprovedBytes = eventArgs.Body.ToArray();
                var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);
                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

                await FinishPayment(paymentApprovedIntegrationEvent.IdProject);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(QUEUE, false, consumer);

            return Task.CompletedTask;
        }

        private async Task FinishPayment(int idProject)
        {
            // Finish payment
            using (var scope = _serviceProvider.CreateScope())
            {
                var projectRepositoy = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

                var project = await projectRepositoy.GetByIdAsync(idProject);

                project.Finish();

                await projectRepositoy.SaveChangesAsync();
            }
        }
    }
}

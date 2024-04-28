using DevFreela.Application.InputModels.Payment;
using DevFreela.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace DevFreela.Infrastructure.Payment
{
    public class PaymentService : IPaymentService
    {
        private const string QUEUE_NAME = "Payments";
        private readonly IMessageBusService _messageBusService;
        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }
        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);
            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}

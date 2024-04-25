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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentBaseUrl;
        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = configuration.GetSection("Services:Payment").Value;
        }
        public async Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var url = $"{_paymentBaseUrl}/api/payments";
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoContent = new StringContent(
                paymentInfoJson,
                Encoding.UTF8,
                "application/json");

            var httpClient = _httpClientFactory.CreateClient("PaymentService");
            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;
        }
    }
}

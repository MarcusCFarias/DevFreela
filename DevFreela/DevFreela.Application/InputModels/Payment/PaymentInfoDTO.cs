using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels.Payment
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int idProject, string creditCardNumber, string cvv, string expiresAt, string description, decimal amount)
        {
            Description = description;
            IdProject = idProject;
            CreditCardNumber = creditCardNumber;
            CVV = cvv;
            ExpiresAt = expiresAt;
            Amount = amount;
        }

        public string Description { get; private set;}
        public decimal Amount { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string CVV { get; private set; }
        public string ExpiresAt { get; private set; }
        public int IdProject { get; private set; }
    }
}


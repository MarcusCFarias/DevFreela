using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels.Payment
{
    public class PaymentInfoInputModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string CreditCard { get; set; }
        public string CVV { get; set; }
        public string Expiration { get; set; }
        public int ProjectId { get; set; }
    }
}

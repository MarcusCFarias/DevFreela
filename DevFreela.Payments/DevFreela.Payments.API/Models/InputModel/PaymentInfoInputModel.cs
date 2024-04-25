namespace DevFreela.Payments.API.Models.InputModel
{
    public class PaymentInfoInputModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiresAt { get; set; }
        public int ProjectId { get; set; }
    }
}

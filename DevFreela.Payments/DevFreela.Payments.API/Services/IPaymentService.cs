using DevFreela.Payments.API.Models.InputModel;

namespace DevFreela.Payments.API.Services
{
    public interface IPaymentService
    {
        Task<bool> Process(PaymentInfoInputModel paymentInfoInputModel);
    }
}

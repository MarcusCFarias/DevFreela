using DevFreela.Payments.API.Models.InputModel;
using DevFreela.Payments.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
            
        }
        [HttpPost]
        public IActionResult Post([FromBody] PaymentInfoInputModel paymentInputModel)
        {
            var result = _paymentService.Process(paymentInputModel);
            
            if (!result.Result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}

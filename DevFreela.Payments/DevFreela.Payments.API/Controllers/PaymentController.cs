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

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var paymentInputModel = new PaymentInfoInputModel
        //    {
        //        Id = id,
        //        Description = "Payment for project 1",
        //        Amount = 100,
        //        Type = "CreditCard",
        //        CreditCard = "1234567890123456",
        //        CVV = "123",
        //        Expiration = "12/2023",
        //        ProjectId = 1
        //    };

        //    return Ok(paymentInputModel);
        //}
    }
}

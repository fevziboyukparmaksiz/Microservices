using FreeCourse.Services.FakePayment.Models;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment(PaymentDto paymentDto)
        {
            //payment Dto ile ödeme işlemi gerçekleşir.
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}

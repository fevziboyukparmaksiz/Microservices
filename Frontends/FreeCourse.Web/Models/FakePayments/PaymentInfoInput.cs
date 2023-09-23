using FreeCourse.Web.Models.Orders;

namespace FreeCourse.Web.Models.FakePayments
{
    public class PaymentInfoInput
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public decimal Price { get; set; }
        public OrderCreateInput Order { get; set; }
    }
}

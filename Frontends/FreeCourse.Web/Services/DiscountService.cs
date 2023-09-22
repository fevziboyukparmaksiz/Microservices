using FreeCourse.Web.Models.Discount;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class DiscountService : IDiscountService
    {
        public async Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }
    }
}

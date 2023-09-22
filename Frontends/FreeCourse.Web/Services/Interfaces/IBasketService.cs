using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models.Baskets;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketViewModel> Get();
        Task<bool> SaveOrUpdate(BasketViewModel basketViewModel);
        Task<bool> Delete();
        Task AddBasketItem(BasketItemViewModel basketItemViewModel);
        Task<bool> DeleteBasketItem(string courseId);
        Task<bool> ApplyDiscount(string discountCode);
        Task<bool> CancelAppliedDiscount();
    }
}

using FreeCourse.Shared.Dtos;
using FreeCourse.Shared.Service;
using FreeCourse.Web.Models.Baskets;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketViewModel> Get()
        {
            var response = await _httpClient.GetAsync("basket");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var basketViewModel = await response.Content.ReadFromJsonAsync<Response<BasketViewModel>>();

            return basketViewModel.Data;
        }

        public async Task<bool> SaveOrUpdate(BasketViewModel basketViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<BasketViewModel>("basket", basketViewModel);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete()
        {
            var response = await _httpClient.DeleteAsync("basket");
            return response.IsSuccessStatusCode;
        }

        public async Task AddBasketItem(BasketItemViewModel basketItemViewModel)
        {
            var basket = await Get();

            if (basket != null)
            {
                if (!basket.BasketItems.Any(x => x.CourseId == basketItemViewModel.CourseId))
                {
                    basket.BasketItems.Add(basketItemViewModel);
                }
            }
            else
            {
                basket = new BasketViewModel();
                basket.BasketItems.Add(basketItemViewModel);
            }

            await SaveOrUpdate(basket);
        }

        public async Task<bool> DeleteBasketItem(string courseId)
        {
            var basket = await Get();

            if (basket == null) return false;

            var deleteBasketItem = basket.BasketItems.FirstOrDefault(x => x.CourseId == courseId);
            var deleteResult = basket.BasketItems.Remove(deleteBasketItem);

            if (deleteBasketItem == null) return false;

            if (!deleteResult) return false;


            //if (!basket.BasketItems.Any())
            //    basket.DiscountCode = null;


            return await SaveOrUpdate(basket);
        }

        public async Task<bool> ApplyDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CancelApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }
}

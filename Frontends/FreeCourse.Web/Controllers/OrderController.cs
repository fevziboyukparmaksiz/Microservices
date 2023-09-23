using FreeCourse.Web.Models.Orders;
using FreeCourse.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;

        public OrderController(IOrderService orderService, IBasketService basketService)
        {
            _orderService = orderService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketService.Get();
            ViewBag.basket = basket;
            return View(new CheckoutInfoInput());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
        {
            //1.yol senkron iletişim
            //var orderStatus = await _orderService.CreateOrder(checkoutInfoInput);

            //2.yol asenkron iletişim.
            var orderSuspend = await _orderService.SuspendOrder(checkoutInfoInput);
            if (!orderSuspend.IsSuccessful)
            {
                var basket = await _basketService.Get();

                ViewBag.basket = basket;
                ViewBag.error = orderSuspend.Error;

                return View();
            }
            //1.yol senkron iletişim
            //return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = orderStatus.OrderId });

            //2.yol asenkron iletişim.
            return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = new Random().Next(1, 1000) });


        }

        public async Task<IActionResult> SuccessfulCheckout(int orderId)
        {
            ViewBag.orderId = orderId;
            return View();
        }
    }
}

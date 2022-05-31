using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private  readonly IProductService productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            string id = HttpContext.User.Identity.Name;

            IEnumerable<OrderDto> orders = orderService.GetOrders(id);

            decimal total = 0;

            foreach (var item in orders)
            {
                total += item.ProductDto.Price;
            }

            ViewBag.Total = total;

            if (orders != null && orders.Count() > 0)
            {
                return View(orders);
            }

            return View();
        }

        public IActionResult AddToCart(int id)
        {
            string userId = HttpContext.User.Identity.Name;

            ProductDto productDto = productService.Read(id);

            if (!string.IsNullOrEmpty(userId))
            {
                
                OrderDto order = new OrderDto
                {
                    CartId = userId,
                    ProductDto = productDto,
                    TotalPrice = productDto.Price
                };

                orderService.AddToCart(order);
            }

            return RedirectToAction(nameof(Index));
        }

        public JsonResult Chekout()
        {
            string id = HttpContext.User.Identity.Name;
            
            //if (cartService.IsRequestCheckout)
            //{
            //    return Json(new { IsSuccess = true, Message = "Your order is placed. Thank for buying!" });
            //}

            return Json(new { IsSuccess = true, Message = "Products out of stock do not add to your request!. Thank for buying!" });
        }

        public IActionResult Delete(ushort id)
        {
            string userId = HttpContext.User.Identity.Name;

            orderService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

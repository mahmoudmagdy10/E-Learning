using Amazon.BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRep cartRep;

        public CartController(ICartRep cartRep)
        {
            this.cartRep = cartRep;
        }

        public IActionResult Index()
        {
            var cart = cartRep.GetCart();
            ViewBag.TotalPrice = cartRep.GetTotalPrice();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            cartRep.AddItem(productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int productId, int quantity)
        {
            cartRep.RemoveItem(productId, quantity);
            return RedirectToAction("Index");
        }
    }
}

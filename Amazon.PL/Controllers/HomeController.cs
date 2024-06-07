using Amazon.BL.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductRep productRep;
        private readonly ICartRep cartRep;
        private readonly IMapper mapper;

        public HomeController(IProductRep productRep , ICartRep cartRep, IMapper mapper)
        {
            this.productRep = productRep;
            this.cartRep = cartRep;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = productRep.GetAll();
            var cartItemCount = cartRep.GetCart();
            if (products.Count() <= 0)
            {
                ViewBag.cartItemsCount = cartItemCount;
                return View();
            }
            ViewBag.cartItemsCount = cartItemCount;
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = productRep.Get(id);
            return View(product);
        }

    }
}

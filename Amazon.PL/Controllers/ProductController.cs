using Amazon.BL.Interface;
using Amazon.BL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRep productRep;
        private readonly IMapper mapper;

        public ProductController(IProductRep productRep, IMapper mapper)
        {
            this.productRep = productRep;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var productModel = productRep.GetAll();
            if (productModel.Count() <= 0)
                return View();

            var products = mapper.Map<List<ProductVM>>(productModel);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                // If the model state is not valid, return a 400 Bad Request with the validation errors
                productRep.Add(product);
                return View();
            }
            return BadRequest(ModelState);
        }
        
        public IActionResult Edit(int id)
        {
            var prodct = productRep.Get(id);
            return View(prodct);
        }
        
        public IActionResult update(ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return a 400 Bad Request with the validation errors
                return BadRequest(ModelState);
            }
            productRep.Update(product);
            return View();
        }

        public IActionResult Details(int id)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return a 400 Bad Request with the validation errors
                return BadRequest(ModelState);
            }
            var product = productRep.Get(id);
            var productVM = mapper.Map<ProductVM>(product);
            return View(productVM);
        }
    }
}

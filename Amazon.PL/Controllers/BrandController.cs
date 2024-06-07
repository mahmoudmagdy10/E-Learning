using Amazon.BL.Helpers;
using Amazon.BL.Interface;
using Amazon.BL.Models;
using Amazon.BL.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandRep brandRep;
        private readonly IMapper mapper;

        public BrandController(IBrandRep brandRep, IMapper mapper)
        {
            this.brandRep = brandRep;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var brandModel = brandRep.GetAll();
            if (brandModel.Count() <= 0)
                return View(Enumerable.Empty<BrandVM>());

            var brands = mapper.Map<List<BrandVM>>(brandModel);
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandVM brand)
        {
            if (brand.ImageFile != null)
            {
                brand.Image = FileHelper.UploadFile("/wwwroot/Files/Brands/Imgs", brand.ImageFile);
                brandRep.Add(brand);
                TempData["SuccessMsg"] = "Brand Created Successfully";
                return View();
            }

            TempData["ErrorMsg"] = "Failed To Create Brand";
            return View();
        }

    }
}

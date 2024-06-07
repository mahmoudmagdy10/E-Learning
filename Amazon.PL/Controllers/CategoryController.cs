using Amazon.BL.Interface;
using Amazon.BL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRep _category;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRep category, IMapper mapper)
        {
            this._category = category;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var categoryData = _category.GetAll();
            if (categoryData.Count() <= 0)
                return View(Enumerable.Empty<CategoryVM>());

            return View(categoryData);
        }

    }
}

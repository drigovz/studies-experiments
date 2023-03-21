using Microsoft.AspNetCore.Mvc;
using ProductsCleanArch.Application.Interfaces;
using System.Threading.Tasks;

namespace ProductsCleanArch.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAsync();
            return View(categories);
        }
    }
}

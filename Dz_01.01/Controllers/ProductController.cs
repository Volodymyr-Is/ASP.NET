using Dz_01._01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dz_01._01.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string searchQueue, int? categoryId, int pageNumber = 1)
        {
            var result = _productService.GetPagedResult(searchQueue, categoryId, pageNumber);

            ViewBag.Categories = _productService.GetCategories();
            ViewBag.SearchTerm = searchQueue;
            ViewBag.SelectedCategoryId = categoryId;

            return View(result);
        }

        public IActionResult Details(int id) { 
            var product = _productService.GetProducts(null, null).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return View("Error");
            }

            return View(product);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dz_01._01.Models
{
    public class ProductService: IProductService
    {
        private readonly List<Product> _products;
        private readonly List<SelectListItem> _categories;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 100, CategoryId = 1 },
                new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 200, CategoryId = 2 },
                new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 300, CategoryId = 1 },
            };

            _categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Category1" },
                new SelectListItem { Value = "2", Text = "Category2" }
            };
        }

        public IEnumerable<Product> GetProducts(string searchQueue, int? categoryId) {
            var searchResult = _products.AsQueryable();

            if (!string.IsNullOrEmpty(searchQueue))
                searchResult = searchResult.Where(p => p.Name.Contains(searchQueue, StringComparison.OrdinalIgnoreCase));

            if (categoryId != null)
                searchResult = searchResult.Where(p => p.CategoryId == categoryId.Value);

            return searchResult.ToList();
        }

        public PagedResult<Product> GetPagedResult(string searchQueue, int? categoryId, int pageNmber)
        {
            const int pageSize = 1;
            var products = GetProducts(searchQueue, categoryId);

            var pagedProducts = products.Skip((pageNmber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResult<Product> 
            { 
                Items = pagedProducts,
                CurrentPage = pageNmber,
                TotalPages = (int)Math.Ceiling(products.Count() / (double)pageSize),
            };
        }

        public List<SelectListItem> GetCategories()
        {
            return _categories;
        }
    }
}

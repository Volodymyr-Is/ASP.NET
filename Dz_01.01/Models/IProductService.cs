using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dz_01._01.Models
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(string searchQueue, int? categoryId);
        PagedResult<Product> GetPagedResult(string searchQueue, int? categoryId, int pageNmber);
        List<SelectListItem> GetCategories();
    }
}

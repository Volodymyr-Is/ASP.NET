using Dz_04._02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dz_04._02.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetProducts() => Ok(_context.Products.ToList());
    }
}

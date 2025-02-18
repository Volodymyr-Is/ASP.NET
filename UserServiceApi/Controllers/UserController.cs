using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServiceApi.Model;

namespace UserServiceApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }

}

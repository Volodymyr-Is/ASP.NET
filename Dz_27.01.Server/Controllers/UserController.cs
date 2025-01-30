using Dz_27._01.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dz_27._01.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
            //if (user == null)
            //    return BadRequest();

            //var updatedUser = await _context.FindAsync<User>(id);

            //if(updatedUser == null)
            //    return NotFound();

            //updatedUser.Name = user.Name;
            //updatedUser.Age = user.Age;

            //_context.Update(updatedUser);
            //await _context.SaveChangesAsync();

            //return Ok(updatedUser);


            if (user == null)
                return BadRequest();
            if (!_context.Users.Any(x => x.Id == id))
                return NotFound();

            user.Id = id;

            _context.Attach<User>(user);
            _context.Update(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}

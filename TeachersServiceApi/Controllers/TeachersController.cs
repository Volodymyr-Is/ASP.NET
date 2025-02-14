using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersServiceApi.Model;

namespace TeachersServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterTeacher([FromBody] Teacher model)
        {
            var result = await _teacherService.RegisterTeacherAsync(model);
            if (result)
                return Ok();
            return BadRequest("Error registering teacher.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher model)
        {
            var result = await _teacherService.UpdateTeacherAsync(id, model);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeleteTeacherAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}

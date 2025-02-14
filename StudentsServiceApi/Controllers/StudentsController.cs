using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsServiceApi.Model;

namespace StudentsServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStudent([FromBody] Student model)
        {
            var result = await _studentService.RegisterStudentAsync(model);
            if (result)
                return Ok();
            return BadRequest("Error registering student.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student model)
        {
            var result = await _studentService.UpdateStudentAsync(id, model);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}

using CoursesServiceApi.Model;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCourse([FromBody] Course model)
        {
            var result = await _courseService.AddCourseAsync(model);
            if (result)
                return Ok();
            return BadRequest("Error adding course.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course model)
        {
            var result = await _courseService.UpdateCourseAsync(id, model);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}

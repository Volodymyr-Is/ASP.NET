using Microsoft.EntityFrameworkCore;

namespace CoursesServiceApi.Model
{
    public class CourseService : ICourseService
    {
        private readonly CourseContext _context;

        public CourseService(CourseContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCourseAsync(int id, Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null) return false;

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Credits = course.Credits;
            existingCourse.Department = course.Department;

            _context.Courses.Update(existingCourse);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }

}

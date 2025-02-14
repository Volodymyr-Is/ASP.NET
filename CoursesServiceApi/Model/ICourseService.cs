namespace CoursesServiceApi.Model
{
    public interface ICourseService
    {
        Task<bool> AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(int id, Course course);
        Task<bool> DeleteCourseAsync(int id);
        Task<Course> GetCourseByIdAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
    }

}

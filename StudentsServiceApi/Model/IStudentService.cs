namespace StudentsServiceApi.Model
{
    public interface IStudentService
    {
        Task<bool> RegisterStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<Student> GetStudentByIdAsync(int id);
        Task<List<Student>> GetAllStudentsAsync();
    }

}

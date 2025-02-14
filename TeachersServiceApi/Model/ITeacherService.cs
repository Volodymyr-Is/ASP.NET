namespace TeachersServiceApi.Model
{
    public interface ITeacherService
    {
        Task<bool> RegisterTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(int id, Teacher teacher);
        Task<bool> DeleteTeacherAsync(int id);
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<List<Teacher>> GetAllTeachersAsync();
    }

}

using Microsoft.EntityFrameworkCore;

namespace TeachersServiceApi.Model
{
    public class TeacherService : ITeacherService
    {
        private readonly TeachersContext _context;

        public TeacherService(TeachersContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTeacherAsync(int id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null) return false;

            existingTeacher.Name = teacher.Name;
            existingTeacher.Email = teacher.Email;
            existingTeacher.Department = teacher.Department;
            existingTeacher.PhoneNumber = teacher.PhoneNumber;

            _context.Teachers.Update(existingTeacher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return false;

            _context.Teachers.Remove(teacher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
    }

}

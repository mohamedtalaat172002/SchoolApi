using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IStudentService
    {
        Task<IQueryable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<String> AddStudent(Student student);
        Task<String> DeleteStudent(int id);
        Task<String> UpdateStudent(Student student);

        public Task<bool> IsNameExist(string nameEn);
        public Task<bool> IsNameExistExcludeSelf(string nameAr, int id);
    }
}

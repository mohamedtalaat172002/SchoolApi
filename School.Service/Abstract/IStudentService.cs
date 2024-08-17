using School.Data.Helper;
using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IStudentService
    {
        Task<IQueryable<Student>> GetAllStudents();
        Task<Student> GetStudentByIdIncludeDept(int id);
        Task<Student> GetStudentByIdWithOutDept(int id);
        Task<String> AddStudent(Student student);
        Task<String> DeleteStudent(Student student);
        Task<String> UpdateStudent(Student student);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);

        public IQueryable<Student> GetStudentsWithFilterAndSearch(StudentOrderEnum studentOrderEnum, String Search);
    }
}

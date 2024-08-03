using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.infrastructure.Abstract;
using School.Service.Abstract;

namespace School.Service.Implementaion
{
    public class StudentService : IStudentService
    {
        private readonly IStudentInfrastructure _studentInfrastructure;

        public StudentService(IStudentInfrastructure studentInfrastructure)
        {
            _studentInfrastructure = studentInfrastructure;
        }

        public async Task<string> AddStudent(Student student)
        {
            await _studentInfrastructure.AddAsync(student);
            return "Succefully Added";
        }

        public async Task<string> DeleteStudent(Student student)

        {
            var transaction = _studentInfrastructure.BeginTransaction();
            try
            {
                await _studentInfrastructure.DeleteAsync(student);
                await transaction.CommitAsync();
                return "Deleted Succefully";

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return "Delete process Failed ";
            }
        }


        public async Task<IQueryable<Student>> GetAllStudents()
        {
            return _studentInfrastructure.GetTableNoTracking()
                .Include(s => s.Department);
        }

        public async Task<Student> GetStudentByIdIncludeDept(int id)
        {
            return await _studentInfrastructure.GetTableNoTracking()
                .Where(s => s.StudID == id)
                .Include(x => x.Department)
                .FirstOrDefaultAsync();

        }

        public async Task<string> UpdateStudent(Student student)
        {
            var std = _studentInfrastructure.UpdateAsync(student);
            return "Updated succefully ";
        }

        public async Task<bool> IsNameExist(string nameAr)
        {
            var student = _studentInfrastructure.GetTableNoTracking().Where(x => x.Name.Equals(nameAr)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string nameAr, int id)
        {

            var student = await _studentInfrastructure.GetTableNoTracking().Where(x => x.Name.Equals(nameAr) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<Student> GetStudentByIdWithOutDept(int id)
        {
            return await _studentInfrastructure.GetByIdAsync(id);
        }
    }
}

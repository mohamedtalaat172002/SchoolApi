using Microsoft.EntityFrameworkCore;
using School.Data.Helper;
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
            await _studentInfrastructure.UpdateAsync(student);
            return "Updated succefully ";
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            var student = _studentInfrastructure.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }
        public async Task<bool> IsNameArExist(string nameAr)
        {
            var student = _studentInfrastructure.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }



        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {

            var student = await _studentInfrastructure.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {

            var student = await _studentInfrastructure.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }



        public async Task<Student> GetStudentByIdWithOutDept(int id)
        {
            return await _studentInfrastructure.GetByIdAsync(id);
        }

        public IQueryable<Student> GetStudentsWithFilterAndSearch(StudentOrderEnum stdsOrderEnum, string Search)
        {
            var Stds = _studentInfrastructure.GetTableNoTracking().Include(s => s.Department).AsQueryable();
            if (Search != null)
            {
                Stds = Stds.Where(s => s.NameEn.Contains(Search) || s.Address.Contains(Search));
            }

            switch (stdsOrderEnum)
            {
                case StudentOrderEnum.StudID:
                    Stds = Stds.OrderBy(s => s.StudID);
                    break;
                case StudentOrderEnum.Name:
                    Stds = Stds.OrderBy(s => s.NameEn);
                    break;
                case StudentOrderEnum.Address:
                    Stds = Stds.OrderBy(s => s.Address);
                    break;
                case StudentOrderEnum.DepartmentName:
                    Stds = Stds.OrderBy(s => s.Department.DNameEn);
                    break;
                default: return Stds;

            }

            return Stds;
        }
    }
}

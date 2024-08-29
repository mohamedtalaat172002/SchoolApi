using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.infrastructure.Abstract;
using School.Service.Abstract;

namespace School.Service.Implementaion
{
    public class DepartementService : IDepartementService
    {
        private readonly IDepartmentInfrastructure _departmentInfrastructure;
        public DepartementService(IDepartmentInfrastructure departmentInfrastructure)
        {
            this._departmentInfrastructure = departmentInfrastructure;
        }

        public async Task<Department> GetDeptById(int departmentId)
        {
            var dept = await _departmentInfrastructure.GetTableNoTracking()
                 .Where(d => d.DID.Equals(departmentId))
                 .Include(d => d.InstructorMgr)
                 .Include(d => d.DepartmentSubjects).ThenInclude(S => S.Subjects)
                 .Include(d => d.Instructors)
                 // .Include(d => d.Students)
                 .FirstOrDefaultAsync();

            return dept;
        }
    }
}

using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IDepartementService
    {
        Task<Department> GetDeptById(int departmentId);

    }
}

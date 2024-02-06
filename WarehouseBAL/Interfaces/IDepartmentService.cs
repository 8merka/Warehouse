using WarehouseDAL.Models;

namespace WarehouseBAL.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        void Create(Department department);
        Department Update(int id, Department department);
        Department Delete(int id);
    }
}

using WarehouseDAL.Models;

namespace WarehouseBAL.Interfaces
{
    public interface IWorkerDepartmentService
    {
        IEnumerable<WorkerDepartment> GetAllWorkerDepartments();
        void Create(WorkerDepartment workerDepartment);
        WorkerDepartment Update(int workerId, int departmentId, WorkerDepartment workerDepartment);
        WorkerDepartment Delete(int workerId, int departmentId);
        Task<bool> ExistsAsync(int id);
    }
}

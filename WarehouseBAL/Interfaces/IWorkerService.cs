using WarehouseDAL.Models;

namespace WarehouseBAL.Interfaces
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetAllWorkers();
        void Create(Worker worker);
        Worker Update(int id, Worker worker);
        Worker Delete(int id);
    }
}

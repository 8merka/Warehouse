using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Logging;
using WarehouseBAL.Interfaces;
using WarehouseDAL.Data;
using WarehouseDAL.Models;

namespace WarehouseBAL.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public WorkerService(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Worker> GetAllWorkers() => _context.Workers;
        public void Create(Worker worker)
        {
            try
            {
                _logger.LogInformation("Trying to create new line into Worker table");
                _context.Workers.Add(worker);
                _context.SaveChanges();
                _logger.LogInformation($"Line {worker.Id} {worker.FirstName} {worker.LastName} {worker.Age} succesfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("Creating new line into Worker table ended");
            }
        }
        public Worker Update(int id, Worker worker)
        {
            Worker updatedWorker = _context.Workers.FirstOrDefault(w => w.Id == id);
            if (updatedWorker != null)
            {
                updatedWorker.FirstName = worker.FirstName;
                updatedWorker.LastName = worker.LastName;
                updatedWorker.Age = worker.Age;

                _context.SaveChanges();
                return updatedWorker;
            }
            return null;
        }
        public Worker Delete(int id)
        {
            Worker deletedWorker = _context.Workers.FirstOrDefault(w => w.Id == id);
            if (deletedWorker != null)
            {
                _context.Workers.Remove(deletedWorker);
                _context.SaveChanges();
                return deletedWorker;
            }
            return null;
        }
    }
}

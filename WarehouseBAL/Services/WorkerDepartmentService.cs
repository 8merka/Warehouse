using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Logging;
using WarehouseBAL.Interfaces;
using WarehouseDAL.Data;
using WarehouseDAL.Models;

namespace WarehouseBAL.Services
{
    public class WorkerDepartmentService : IWorkerDepartmentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public WorkerDepartmentService(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<WorkerDepartment> GetAllWorkerDepartments() => _context.WorkerDepartments;
        public void Create(WorkerDepartment workerDepartment)
        {
            try
            {
                _logger.LogInformation("Trying to create new line into WorkerDepartment table");
                _context.WorkerDepartments.Add(workerDepartment);
                _context.SaveChanges();
                _logger.LogInformation($"Line {workerDepartment.WorkerId} {workerDepartment.DepartmentId} succesfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("Creating new line into WorkerDepartment table ended");
            }
        }

        public WorkerDepartment Update(int workerId, int departmentId, WorkerDepartment workerDepartment)
        {
            WorkerDepartment updatedWorkerDepartment = _context.WorkerDepartments.FirstOrDefault(wd => wd.WorkerId == workerId && wd.DepartmentId == departmentId);
            if (updatedWorkerDepartment != null)
            {
                updatedWorkerDepartment.WorkerId = workerId;
                updatedWorkerDepartment.DepartmentId = departmentId;

                _context.SaveChanges();
                return updatedWorkerDepartment;
            }
            return null;
        }
        public WorkerDepartment Delete(int workerId, int departmentId)
        {
            WorkerDepartment deletedWorkerDepartment = _context.WorkerDepartments.FirstOrDefault(wd => wd.WorkerId == workerId && wd.DepartmentId == departmentId);
            if (deletedWorkerDepartment != null)
            {
                _context.WorkerDepartments.Remove(deletedWorkerDepartment);
                _context.SaveChanges();
                return deletedWorkerDepartment;
            }
            return null;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }
    }
}

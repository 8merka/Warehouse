using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Logging;
using WarehouseBAL.Interfaces;
using WarehouseDAL.Data;
using WarehouseDAL.Models;

namespace WarehouseBAL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public DepartmentService(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Department> GetAllDepartments() => _context.Departments;
        public void Create(Department department)
        {
            try
            {
                _logger.LogInformation("Trying to create new line into Department table");
                _context.Departments.Add(department);
                _context.SaveChanges();
                _logger.LogInformation($"Line {department.Id} {department.Name} succesfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("Creating new line into Department table ended");
            }

        }
        public Department Update(int id, Department department)
        {
            Department updatedDepartment = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (updatedDepartment != null)
            {
                updatedDepartment.Name = department.Name;

                _context.SaveChanges();
                _logger.LogInformation("Log of updating line into Department table ended");
                return updatedDepartment;
            }
            return null;
        }
        public Department Delete(int id)
        {
            Department deletedDepartment = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (deletedDepartment != null)
            {
                _context.Departments.Remove(deletedDepartment);

                _context.SaveChanges();
                return deletedDepartment;
            }
            return null;
        }
    }
}

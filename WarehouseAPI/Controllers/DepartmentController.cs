using Microsoft.AspNetCore.Mvc;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;


namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            return Ok(_departmentService.GetAllDepartments());
        }
        [HttpPost("CreateDepartment")]
        public IActionResult Create(DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Department department = new Department
            {
                Name = departmentDTO.Name,
            };
            _departmentService.Create(department);
            return Ok();
        }
        [HttpPut("UpdateDepartment/{id}")]
        public IActionResult Update(int id, DepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Department department = new Department
            {
                Name = departmentDTO.Name
            };
            Department updatedDepartment = _departmentService.Update(id, department);
            if (updatedDepartment == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult Delete(int id)
        {
            Department deletedDepartment = _departmentService.Delete(id);
            if (deletedDepartment == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

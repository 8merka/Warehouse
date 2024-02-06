using Microsoft.AspNetCore.Mvc;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;

namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerDepartmentController : ControllerBase
    {
        private readonly IWorkerDepartmentService _workerDepartmentService;

        public WorkerDepartmentController(IWorkerDepartmentService workerDepartmentService)
        {
            _workerDepartmentService = workerDepartmentService;
        }

        [HttpGet("GetAllWorkerDepartments")]
        public IActionResult GetAllWorkerDepartments()
        {
            return Ok(_workerDepartmentService.GetAllWorkerDepartments());
        }

        [HttpPost("CreateWorkerDepartment")]
        public IActionResult Create(WorkerDepartmentDTO workerDepartmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkerDepartment workerDepartment = new WorkerDepartment
            {
                WorkerId = workerDepartmentDTO.WorkerId,
                DepartmentId = workerDepartmentDTO.DepartmentId,

            };

            _workerDepartmentService.Create(workerDepartment);
            return Ok();
        }

        [HttpPut("UpdateWorkerDepartment/{id}")]
        public IActionResult Update(int workerId, int departmentId, WorkerDepartmentDTO workerDepartmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkerDepartment workerDepartment = new WorkerDepartment
            {
                WorkerId = workerDepartmentDTO.WorkerId,
                DepartmentId = workerDepartmentDTO.DepartmentId,
            };

            WorkerDepartment updatedWorkerDepartment = _workerDepartmentService.Update(workerId, departmentId, workerDepartment);

            if (updatedWorkerDepartment == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("DeleteWorkerDepartment/{id}")]
        public IActionResult Delete(int workerId, int departmentId)
        {
            WorkerDepartment deletedWorkerDepartment = _workerDepartmentService.Delete(workerId, departmentId);

            if (deletedWorkerDepartment == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

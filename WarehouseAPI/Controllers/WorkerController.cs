using Microsoft.AspNetCore.Mvc;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;

namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet("GetAllWorkers")]
        public IActionResult GetAllWorkers()
        {
            return Ok(_workerService.GetAllWorkers());
        }

        [HttpPost("CreateWorker")]
        public IActionResult Create(WorkerDTO workerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Worker worker = new Worker
            {
                FirstName = workerDTO.FirstName,
                LastName = workerDTO.LastName,
                Age = workerDTO.Age
            };

            _workerService.Create(worker);
            return Ok();
        }

        [HttpPut("UpdateWorker/{id}")]
        public IActionResult Update(int id, WorkerDTO workerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Worker worker = new Worker
            {
                FirstName = workerDTO.FirstName,
                LastName = workerDTO.LastName,
                Age = workerDTO.Age
            };

            Worker updatedWorker = _workerService.Update(id, worker);

            if (updatedWorker == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("DeleteWorker/{id}")]
        public IActionResult Delete(int id)
        {
            Worker deletedWorker = _workerService.Delete(id);

            if (deletedWorker == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

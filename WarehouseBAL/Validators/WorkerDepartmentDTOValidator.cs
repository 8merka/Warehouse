using FluentValidation;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;

namespace WarehouseBAL.Validators
{
    public class WorkerDepartmentDTOValidator : AbstractValidator<WorkerDepartmentDTO>
    {
        private readonly IWorkerDepartmentService _workerDepartmentService;
        public WorkerDepartmentDTOValidator(IWorkerDepartmentService workerDepartmentService)
        {
            _workerDepartmentService = workerDepartmentService;

            RuleFor(wd => wd.WorkerId)
                .Must(workerId => Task.Run(async () => await workerDepartmentService.ExistsAsync(workerId)).Result)
                .WithMessage("WorkerDepartment with given ID is not exists")
                .NotEmpty();
            RuleFor(wd => wd.DepartmentId)
                .Must(departmentId => Task.Run(async () => await workerDepartmentService.ExistsAsync(departmentId)).Result)
                .WithMessage("WorkerDepartment with given ID is not exists")
                .NotEmpty();
        }
    }
}

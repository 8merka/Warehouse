using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WarehouseDAL.DTO;


namespace WarehouseBAL.Validators
{
    public class WorkerDTOValidator : AbstractValidator<WorkerDTO>
    {
        public WorkerDTOValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .Length(0, 50)
                .Matches(@"^\s*[a-zA-Zа-яА-Я-\s]+$")
                .WithMessage("Use letters and hyphens only!");
            RuleFor(p => p.LastName)
                .NotEmpty()
                .Length(0, 50)
                .Matches(@"^\s*[a-zA-Zа-яА-Я-\s]+$")
                .WithMessage("Use letters and hyphens only!");
            RuleFor(x => x.Age)
                .GreaterThan(17)
                .WithMessage("Age must be more or equals 18");
        }
    }
}

using FluentValidation;
using WarehouseDAL.DTO;

namespace WarehouseBAL.Validators
{
    public class DepartmentDTOValidator : AbstractValidator<DepartmentDTO>
    {
        public DepartmentDTOValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .Length(0, 50)
                .Matches(@"^\s*[a-zA-Zа-яА-Я-\s]+$")
                .WithMessage("Use letters and hyphens only!");

        }
    }
}

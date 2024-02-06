using FluentValidation;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;

namespace WarehouseBAL.Validators
{

    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        private readonly IProductService _productService;
        public ProductDTOValidator(IProductService productService) 
        { 
            _productService = productService;

            RuleFor(p => p.DepartmentId)
                .Must(departmentId => Task.Run(async () => await _productService.ExistsAsync(departmentId)).Result)
                .WithMessage("Product with given ID is not exists")
                .NotEmpty();

            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(0, 50)
                .Matches(@"^\s*[0-9a-zA-Zа-яА-Я-\s]+$")
                .WithMessage("Use letters, numbers and hyphens only!");
            RuleFor(p => p.Manufacturer)
                .NotEmpty()
                .Length(0, 50)
                .Matches(@"^\s*[0-9a-zA-Zа-яА-Я-\s]+$")
                .WithMessage("Use letters, numbers and hyphens only!");
            RuleFor(x => x.WarrantyEndDate)
                .NotEmpty()
                .Must((product, warrantyEndDate) => warrantyEndDate > product.WarrantyStartDate.AddMonths(1))
                .WithMessage("The warranty period must be more than one month from the start date.");
        }
    }
}

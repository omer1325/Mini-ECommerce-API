using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please Write Product Name")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Product name must be between 5 and 150 characters");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Stock cannot be empty")
                .Must(s => s >= 0)
                    .WithMessage("Stock cannot be less than 0");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Price cannot be empty")
                .Must(s => s >= 0)
                    .WithMessage("Price cannot be less than 0");
        }
    }
}

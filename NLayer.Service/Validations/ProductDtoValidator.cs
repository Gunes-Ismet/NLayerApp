using FluentValidation;
using NLayer.Core.DTO_s;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            // Value tipler default olarak 0 değerini alıyor. Bundan dolayı NotNull, NotEmpty ile kontrol edilemez. Bunun yerine bir aralık belirtilmesi gerekir. String referans tipte olduğu için null olabilir.
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category must be selected");

        }
    }
}

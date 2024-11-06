
using FluentValidation;
using TodoListify.Models.Dtos.Categories.Requests;

namespace TodoListify.Service.Validation.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(c => c.Name)
          .NotEmpty().WithMessage("Kategori ismi boş bırakılamaz.")
          .Length(2, 40).WithMessage("Kategori ismi minimum 2, maksimum 40 karakter olabilir.")
          .Matches(@"^[a-zA-Z\s]*$").WithMessage("Kategori ismi özel karakterler ve sayılar içeremez.");
    }
}

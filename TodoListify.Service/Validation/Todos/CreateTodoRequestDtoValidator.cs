
using FluentValidation;
using TodoListify.Models.Dtos.Todos.Requests;

namespace TodoListify.Service.Validation.Todos;

public class CreateTodoRequestDtoValidator : AbstractValidator<CreateTodoRequest>
{
    public CreateTodoRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Başlığı boş olamaz.")
            .Length(2, 50).WithMessage("Görev Başlığı Minimum 2 max 50 karakterli olmalıdır.");


        RuleFor(x => x.Description).NotEmpty().WithMessage("Görev açıklaması boş olamaz.");
    }
}

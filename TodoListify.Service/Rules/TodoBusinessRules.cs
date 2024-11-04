

using Core.Exceptions;
using TodoListify.Models.Entities;

namespace TodoListify.Service.Rules;

public class TodoBusinessRules
{
    public virtual void TodoIsNullCheck(Todo todo)
    {
        if (todo is null)
        {
            throw new NotFoundException("İlgili görev bulunamadı.");
        }
    }
}

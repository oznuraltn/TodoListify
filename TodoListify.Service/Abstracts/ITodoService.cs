
using Core.Responses;
using TodoListify.Models.Dtos.Todos.Requests;
using TodoListify.Models.Dtos.Todos.Responses;

namespace TodoListify.Service.Abstracts;

public interface ITodoService
{
    ReturnModel<List<TodoResponseDto>> GetAll();
    ReturnModel<TodoResponseDto?> GetById(Guid id);
    ReturnModel<TodoResponseDto> Add(CreateTodoRequest dto,string userId);
    ReturnModel<TodoResponseDto> Update(UpdateTodoRequest dto);
    ReturnModel<TodoResponseDto> Remove(Guid id);
}


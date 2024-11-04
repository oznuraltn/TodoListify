

using AutoMapper;
using Core.Responses;
using TodoListify.DataAccess.Abstracts;
using TodoListify.Models.Dtos.Todos.Requests;
using TodoListify.Models.Dtos.Todos.Responses;
using TodoListify.Models.Entities;
using TodoListify.Service.Abstracts;
using TodoListify.Service.Rules;

namespace TodoListify.Service.Concretes;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    private readonly TodoBusinessRules _businessRules;

    public TodoService(ITodoRepository todoRepository, IMapper mapper, TodoBusinessRules businessRules)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<TodoResponseDto> Add(CreateTodoRequest create, string userId)
    {
        Todo createdTodo = _mapper.Map<Todo>(create);
        createdTodo.CreatedDate = DateTime.Now;  
        createdTodo.Id = Guid.NewGuid();
        createdTodo.UserId = userId;

        _todoRepository.Add(createdTodo);

        TodoResponseDto response = _mapper.Map<TodoResponseDto>(createdTodo);

        return new ReturnModel<TodoResponseDto>
        {
            Data = response,
            Message = "Görev eklendi",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<List<TodoResponseDto>> GetAll()
    {
        List<Todo> todos = _todoRepository.GetAll();
        List<TodoResponseDto> responses = _mapper.Map<List<TodoResponseDto>>(todos);

        return new ReturnModel<List<TodoResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<TodoResponseDto?> GetById(Guid id)
    {
        var todo = _todoRepository.GetById(id);
        var response = _mapper.Map<TodoResponseDto?>(todo);
        _businessRules.TodoIsNullCheck(todo);

        return new ReturnModel<TodoResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<TodoResponseDto> Remove(Guid id)
    {
        var todo = _todoRepository.GetById(id);
        if (todo == null)
        {
            return new ReturnModel<TodoResponseDto>
            {
                Data = null,
                Message = "Görev bulunamadı",
                StatusCode = 404,
                Success = false,
            };
        }

        var deletedTodo = _todoRepository.Remove(todo);
        var response = _mapper.Map<TodoResponseDto>(deletedTodo);

        return new ReturnModel<TodoResponseDto>
        {
            Data = response,
            Message = "Görev silindi",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<TodoResponseDto> Update(UpdateTodoRequest updateTodo)
    {
        Todo todo = _todoRepository.GetById(updateTodo.Id);

        if (todo == null)
        {
            return new ReturnModel<TodoResponseDto>
            {
                Data = null,
                Message = "Görev bulunamadı",
                StatusCode = 404,
                Success = false,
            };
        }

        _mapper.Map(updateTodo, todo);
        todo.UpdatedDate = DateTime.Now;

        Todo updatedTodo = _todoRepository.Update(todo);

        TodoResponseDto dto = _mapper.Map<TodoResponseDto>(updatedTodo);

        return new ReturnModel<TodoResponseDto>
        {
            Data = dto,
            Message = "Görev güncellendi",
            StatusCode = 200,
            Success = true,
        };
    }
}


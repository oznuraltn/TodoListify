
using static System.Runtime.InteropServices.JavaScript.JSType;
using TodoListify.Models.Dtos.Categories.Requests;
using TodoListify.Models.Dtos.Categories.Responses;
using TodoListify.Models.Dtos.Todos.Requests;
using TodoListify.Models.Dtos.Todos.Responses;
using TodoListify.Models.Entities;
using AutoMapper;

namespace TodoListify.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTodoRequest, Todo>();
        CreateMap<UpdateTodoRequest, Todo>();
        CreateMap<Todo, TodoResponseDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));


        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();
    }
}

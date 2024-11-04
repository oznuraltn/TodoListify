

using Core.Responses;
using TodoListify.Models.Dtos.Categories.Requests;
using TodoListify.Models.Dtos.Categories.Responses;

namespace TodoListify.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto?> GetById(int id);
    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest dto);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory);
    ReturnModel<CategoryResponseDto> Remove(int id);
}


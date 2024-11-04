

using AutoMapper;
using Core.Responses;
using TodoListify.DataAccess.Abstracts;
using TodoListify.Models.Dtos.Categories.Requests;
using TodoListify.Models.Dtos.Categories.Responses;
using TodoListify.Models.Entities;
using TodoListify.Service.Abstracts;
using TodoListify.Service.Rules;

namespace TodoListify.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest dto)
    {
        _categoryBusinessRules.CheckIfCategoryNameIsValid(dto.Name);

        Category createdCategory = _mapper.Map<Category>(dto);
        _categoryRepository.Add(createdCategory);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Kategori eklendi",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        var response = _mapper.Map<CategoryResponseDto?>(category);

        return new ReturnModel<CategoryResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        var category = _categoryRepository.GetById(id);
        var deletedCategory = _categoryRepository.Remove(category);

        var response = _mapper.Map<CategoryResponseDto>(deletedCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Kategori silindi",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
    {
        Category category = _categoryRepository.GetById(updateCategory.Id);

        if (category == null)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = "Kategori bulunamadı",
                StatusCode = 404,
                Success = false
            };
        }

        _mapper.Map(updateCategory, category);

        Category updatedCategory = _categoryRepository.Update(category);
        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);


        return new ReturnModel<CategoryResponseDto>
        {
            Data = dto,
            Message = "Kategori Güncellendi",
            StatusCode = 200,
            Success = true,
        };
    }
}


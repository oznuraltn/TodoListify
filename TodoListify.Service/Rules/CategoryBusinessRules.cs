
using Core.Exceptions;
using TodoListify.DataAccess.Abstracts;

namespace TodoListify.Service.Rules;

public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
{
    public void CheckIfCategoryNameIsValid(string categoryName)
    {
        if (categoryName.Length < 3 || categoryName.Length > 50)
        {
            throw new BusinessException("Kategori adı en az 3, en fazla 50 karakter olmalıdır.");
        }
    }
}


using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using TodoListify.Models.Entities;

namespace TodoListify.Service.Rules;

public class UserBusinessRules(UserManager<User> _userManager)
{
    public async Task CheckIfEmailIsUniqueAsync(string email)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        if (existingUser != null)
        {
            throw new BusinessException("Bu e-posta adresi zaten kullanılıyor.");
        }
    }

    public void CheckIfPasswordIsStrong(string password)
    {
        var hasUpperCase = password.Any(char.IsUpper);
        var hasDigit = password.Any(char.IsDigit);
        var hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

        if (!(hasUpperCase && hasDigit && hasSpecialChar))
        {
            throw new BusinessException("Parola en az bir büyük harf, bir rakam ve bir özel karakter içermelidir.");
        }
    }

}
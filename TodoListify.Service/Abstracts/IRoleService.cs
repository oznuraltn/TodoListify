
using TodoListify.Models.Dtos.Users.Requests;

namespace TodoListify.Service.Abstracts;

public interface IRoleService
{
    Task<string> AddRoleToUser(RoleAddToUserRequestDto dto);
    Task<List<string>> GetAllRolesByUserId(string userId);
    Task<string> AddRoleAsync(string name);
}

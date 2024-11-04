

using TodoListify.Models.Dtos.Tokens.Responses;
using TodoListify.Models.Entities;

namespace TodoListify.Service.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}

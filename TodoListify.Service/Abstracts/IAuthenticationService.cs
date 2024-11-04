
using Core.Responses;
using TodoListify.Models.Dtos.Tokens.Responses;
using TodoListify.Models.Dtos.Users.Requests;

namespace TodoListify.Service.Abstracts;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
}

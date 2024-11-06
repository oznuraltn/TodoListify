using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListify.Models.Dtos.Users.Requests;
using TodoListify.Service.Abstracts;

namespace TodoListify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RolesController(IRoleService roleService) : ControllerBase
{
    [HttpPost("addroletouser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] RoleAddToUserRequestDto dto)
    {
        var result = roleService.AddRoleToUser(dto);
        return Ok(result);
    }

    [HttpGet("getallrolesbyid")]
    public async Task<IActionResult> GetAllRolesByUserId([FromQuery] string userId)
    {
        var result = roleService.GetAllRolesByUserId(userId);
        return Ok(result);
    }

    [HttpPost("addrole")]
    public async Task<IActionResult> AddRoleAsync([FromQuery] string Name)
    {
        var result = roleService.AddRoleAsync(Name);
        return Ok(result);
    }

}

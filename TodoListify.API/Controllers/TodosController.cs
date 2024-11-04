using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoListify.Models.Dtos.Todos.Requests;
using TodoListify.Service.Abstracts;

namespace TodoListify.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(ITodoService _todoService,DecoderService decoderService) : CustomBaseController
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _todoService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateTodoRequest dto)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _todoService.Add(dto,userId);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _todoService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateTodoRequest dto)
    {
        var result = _todoService.Update(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _todoService.Remove(id);
        return Ok(result);
    }
}

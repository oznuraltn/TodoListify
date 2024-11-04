
using Microsoft.AspNetCore.Identity;

namespace TodoListify.Models.Entities;

public sealed class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string City { get; set; }
    public List<Todo> Todos { get; set; }
}
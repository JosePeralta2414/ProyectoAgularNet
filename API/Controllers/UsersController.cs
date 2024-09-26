using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();

        return users;
    }

    [HttpGet("{id}")]
    public ActionResult<AppUser> GetUsersById(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null) return NotFound();

        return Ok(user);
    }
}
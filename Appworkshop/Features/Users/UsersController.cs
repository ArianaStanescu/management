using System.Net.Sockets;
using Appworkshop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appworkshop.Features.Users;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UsersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Add(UserRequest userRequest)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = userRequest.Username,
            Email = userRequest.Email,
            Password = userRequest.Password

        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return Ok(user);
    }


    [HttpGet]
    public async Task<ActionResult<UserResponse>> Get()
    {
        var users = await _dbContext.Users.Select(
            user => new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            }
        ).ToListAsync();
        return Ok(
           users  
        );
    }
    
    
    /*
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> Get([FromRoute] string id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(entity => entity.Id == id);
        if (user == null)
        {
            return NotFound("Id not found");
        }

        return Ok(
            new UserResponse{
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
                }
        );
    }
    
*/
}
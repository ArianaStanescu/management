using System.ComponentModel.DataAnnotations;

namespace Appworkshop.Features.Users;

public class UserRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}
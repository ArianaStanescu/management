using System.ComponentModel.DataAnnotations;
using Appworkshop.Base;

namespace Appworkshop.Features.Users;

public class User : Entity
{
    public string Username { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
   // []
    public string Password { get; set; }
}
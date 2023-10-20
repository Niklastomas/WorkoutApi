
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Auth.Models;

public class AppUser : IdentityUser
{
  public Guid UserId { get; set; }
}

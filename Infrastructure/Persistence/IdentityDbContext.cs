using Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class IdentityDbContext : IdentityDbContext<AppUser>
{
  public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
  { }
}

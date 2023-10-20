using Application.Auth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Auth;

public class UserService : IUserService
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public UserService(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public Guid? GetUserId()
  {
    var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    try
    {
      return Guid.Parse(userId);
    }
    catch (Exception)
    {
      return null;
    }
  }
}

using Application.Auth.DTOs;
using Infrastructure.Auth;

namespace Application.Auth;

public interface IAuthService
{
  Task<AuthResponse?> Register(RegisterDto registerDto);
  Task<AuthResponse?> Login(LoginDto loginDto);
}

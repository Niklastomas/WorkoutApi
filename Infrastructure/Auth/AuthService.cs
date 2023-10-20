using Application.Auth;
using Application.Auth.DTOs;
using Domain;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Auth;

public class AuthService : IAuthService
{
  private readonly UserManager<AppUser> _userManager;
  private readonly IUserRepository _userRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly JwtCreator _jwtCreator;

  public AuthService(
    UserManager<AppUser> userManager,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IConfiguration config)
  {
    _userManager = userManager;
    _userRepository = userRepository;
    _unitOfWork = unitOfWork;
    _jwtCreator = new JwtCreator(config);

  }

  public async Task<AuthResponse?> Login(LoginDto loginDto)
  {
    var appUser = await _userManager.FindByNameAsync(loginDto.Username);

    if (appUser is null)
    {
      return null;
    }

    if (!await _userManager.CheckPasswordAsync(appUser, loginDto.Password))
    {
      return null;
    }

    return new AuthResponse
    {
      Token = _jwtCreator.GenerateToken(appUser)
    };
  }

  public async Task<AuthResponse?> Register(RegisterDto registerDto)
  {
    var currentAppUser = await _userManager.FindByEmailAsync(registerDto.Email);

    if (currentAppUser is not null)
    {
      return null;
    }

    if (registerDto.Password != registerDto.PasswordConfirmation)
    {
      return null;
    }

    var user = new User(registerDto.UserName, registerDto.Email);
    var createdUser = await _userRepository.CreateAsync(user, CancellationToken.None);
    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

    if (createdUser is null)
    {
      return null;
    }

    var appUser = new AppUser()
    {
      UserName = registerDto.UserName,
      Email = registerDto.Email,
      UserId = createdUser.Id,
    };

    var result = await _userManager.CreateAsync(appUser, registerDto.Password);

    if (result.Errors.Any())
    {
      return null;
    }

    return new AuthResponse
    {
      Token = _jwtCreator.GenerateToken(appUser),
    };
  }

}

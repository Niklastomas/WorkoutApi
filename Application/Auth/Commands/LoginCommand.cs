using Application.Auth.DTOs;
using Application.Models;
using Infrastructure.Auth;
using MediatR;

namespace Application.Auth.Commands;

public record LoginCommand(LoginDto LoginDto) : IRequest<ResponseData<AuthResponse>>;


public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseData<AuthResponse>>
{
  private readonly IAuthService _authService;

  public LoginCommandHandler(IAuthService authService)
  {
    _authService = authService;
  }

  public async Task<ResponseData<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
  {
    var response = await _authService.Login(request.LoginDto);

    if (response is null)
    {
      return new ResponseData<AuthResponse>("Failed to login");
    }

    return new ResponseData<AuthResponse>(response);
  }
}

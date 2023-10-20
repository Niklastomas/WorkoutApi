using Application.Auth.DTOs;
using Application.Models;
using Infrastructure.Auth;
using MediatR;

namespace Application.Auth.Commands
{
  public record RegisterUserCommand(RegisterDto RegisterDto) : IRequest<ResponseData<AuthResponse>>;

  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseData<AuthResponse>>
  {
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IAuthService authService)
    {
      _authService = authService;
    }

    public async Task<ResponseData<AuthResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      var response = await _authService.Register(request.RegisterDto);


      if (response is null)
      {
        return new ResponseData<AuthResponse>("Failed to register user");
      }

      return new ResponseData<AuthResponse>(response);
    }
  }
}

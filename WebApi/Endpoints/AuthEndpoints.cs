using Application.Auth.Commands;
using Application.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

public static class AuthEndpoints
{
  public static WebApplication AddAuthEndpoints(this WebApplication app)
  {

    var baseUrl = "/api/auth";

    app.MapPost($"{baseUrl}/register", async (ISender sender, [FromBody] RegisterDto registerDto) =>
    {
      var response = await sender.Send(new RegisterUserCommand(registerDto));

      if (response.Success)
      {
        return Results.Ok(response.Data);
      }

      return Results.BadRequest(response.ErrorMessage);
    });

    app.MapPost($"{baseUrl}/login", async (ISender sender, [FromBody] LoginDto loginDto) =>
    {
      var response = await sender.Send(new LoginCommand(loginDto));

      if (response.Success)
      {
        return Results.Ok(response.Data);
      }

      return Results.BadRequest(response.ErrorMessage);
    });

    return app;
  }

}

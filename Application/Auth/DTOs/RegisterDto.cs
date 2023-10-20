using System.ComponentModel.DataAnnotations;

namespace Application.Auth.DTOs;

public class RegisterDto
{
  [Required]
  public string UserName { get; set; } = string.Empty;

  [Required]
  public string Email { get; set; } = string.Empty;

  [Required]
  public string Password { get; set; } = string.Empty;

  [Required]
  public string PasswordConfirmation { get; set; } = string.Empty;
}

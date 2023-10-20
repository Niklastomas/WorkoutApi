namespace Domain.Entities;

public class User : BaseEntity
{
  public User(string username, string email)
  {
    Username = username;
    Email = email;
  }

  public string Username { get; private set; } = string.Empty;
  public string Email { get; private set; } = string.Empty;
  public string FirstName { get; private set; } = string.Empty;
  public string LastName { get; private set; } = string.Empty;
  public int? Age { get; private set; }
  public int? Length { get; private set; }
  public int? Height { get; private set; }
  public int? Weight { get; private set; }
  public int? MaxHeartRate { get; private set; }
  public string Country { get; private set; } = string.Empty;
}

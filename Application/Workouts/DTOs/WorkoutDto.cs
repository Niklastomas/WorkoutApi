using Domain.Enums;

namespace Application.Workouts.DTOs;

public class WorkoutDto
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int Duration { get; set; }
  public Feeling Feeling { get; set; }
  public List<WorkoutNoteDto> Notes { get; set; } = new();
}

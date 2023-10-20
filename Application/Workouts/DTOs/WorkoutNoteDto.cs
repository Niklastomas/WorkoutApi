namespace Application.Workouts.DTOs;

public class WorkoutNoteDto
{
  public WorkoutNoteDto(string title, string content, Guid id)
  {
    Title = title;
    Content = content;
    WorkoutId = id;
  }

  public WorkoutNoteDto()
  {

  }

  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public Guid? WorkoutId { get; set; }
}

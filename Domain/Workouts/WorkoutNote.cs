namespace Domain.Entities;

public class WorkoutNote : BaseEntity
{
  public WorkoutNote(string title, string content, Guid workoutId)
  {
    Id = Guid.NewGuid();
    Title = title;
    Content = content;
    WorkoutId = workoutId;
  }
  public string Title { get; private set; } = string.Empty;
  public string Content { get; private set; } = string.Empty;
  public Guid WorkoutId { get; private set; }
}

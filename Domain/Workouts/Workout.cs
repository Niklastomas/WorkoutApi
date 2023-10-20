using Domain.Enums;

namespace Domain.Entities
{
  public class Workout : AggregateRoot
  {
    public Workout(string name, int duration, Feeling feeling)
    {
      Id = Guid.NewGuid();
      Name = name;
      Duration = duration;
      Feeling = feeling;
      CreateDate = DateTime.UtcNow;
    }

    private readonly List<WorkoutNote> _notes = new();

    public string Name { get; private set; } = string.Empty;
    public int Duration { get; private set; }
    public Feeling Feeling { get; private set; }
    public Guid UserId { get; private set; }
    public IReadOnlyList<WorkoutNote> Notes => _notes;

    public void SetUserId(Guid userId)
    {
      UserId = userId;
    }

    public void AddNote(WorkoutNote note)
    {
      _notes.Add(note);
    }
  }
}

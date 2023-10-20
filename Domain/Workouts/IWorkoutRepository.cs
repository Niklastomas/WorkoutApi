using Domain.Entities;

namespace Domain.Repositories;

public interface IWorkoutRepository : IBaseRepository<Workout>
{
  Task<IEnumerable<Workout>> GetAsync(Guid userId, CancellationToken cancellationToken);
  Task<Workout?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken);
  Task AddNoteAsync(Guid workoutId, WorkoutNote note, CancellationToken cancellationToken);
}

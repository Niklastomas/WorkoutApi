using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
{
  public WorkoutRepository(WorkoutDbContext dbContext) : base(dbContext)
  {
  }

  public async Task AddNoteAsync(Guid workoutId, WorkoutNote note, CancellationToken cancellationToken)
  {
    var workout = await GetByIdAsync(workoutId, cancellationToken);

    if (workout is null)
    {
      return;
    }

    workout.AddNote(note);
  }

  public async Task<IEnumerable<Workout>> GetAsync(Guid userId, CancellationToken cancellationToken)
  {
    return await _entities.Where(x => x.UserId == userId).Include(x => x.Notes).ToListAsync();
  }

  public async Task<Workout?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken)
  {
    return await _entities.Where(x => x.Id == id && x.UserId == userId).FirstOrDefaultAsync();
  }
}

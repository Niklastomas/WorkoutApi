using Domain;
using Infrastructure.Persistence;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
  private readonly WorkoutDbContext _dbContext;

  public UnitOfWork(WorkoutDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task SaveChangesAsync(CancellationToken cancellationToken)
  {
    await _dbContext.SaveChangesAsync(cancellationToken);
  }
}

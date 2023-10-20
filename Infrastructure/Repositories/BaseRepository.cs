using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
  protected readonly WorkoutDbContext _dbContext;
  protected readonly DbSet<TEntity> _entities;

  public BaseRepository(WorkoutDbContext dbContext)
  {
    _dbContext = dbContext;
    _entities = dbContext.Set<TEntity>();
  }

  public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var result = await _entities.AddAsync(entity, cancellationToken);
    return result.Entity;
  }

  public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
  {
    var record = await _entities.FirstOrDefaultAsync(x => x.Id == id);

    if (record is not null)
    {
      _entities.Remove(record);
    }
  }

  public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
  {
    return await _entities.ToListAsync(cancellationToken);
  }

  public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
  {
    return await _entities.FirstOrDefaultAsync(x => x.Id == id);
  }
}

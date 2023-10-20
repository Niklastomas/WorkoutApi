using Domain.Entities;

namespace Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
  Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
  Task DeleteAsync(Guid id, CancellationToken cancellationToken);
  Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
  Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);
}

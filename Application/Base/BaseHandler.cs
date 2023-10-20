using Domain;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Base;

public abstract class BaseHandler<TEntity> where TEntity : BaseEntity
{
  protected readonly IBaseRepository<TEntity> _repository;
  protected readonly IUnitOfWork _unitOfWork;

  public BaseHandler(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
  {
    _repository = repository;
    _unitOfWork = unitOfWork;
  }
}

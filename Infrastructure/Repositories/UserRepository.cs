using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(WorkoutDbContext dbContext) : base(dbContext)
    { }
  }
}

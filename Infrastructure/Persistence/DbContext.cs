using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class WorkoutDbContext : DbContext
{
  public WorkoutDbContext(DbContextOptions<WorkoutDbContext> dbContext) : base(dbContext)
  { }

  public DbSet<Workout> Workouts { get; set; }
  public DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkoutConfiguration).Assembly);
    base.OnModelCreating(modelBuilder);
  }
}

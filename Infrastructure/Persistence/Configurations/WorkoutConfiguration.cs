using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
  public void Configure(EntityTypeBuilder<Workout> builder)
  {

    builder.Property(x => x.Id).ValueGeneratedNever();

    var navigation = builder.Metadata.FindNavigation(nameof(Workout.Notes));
    navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}

public class WorkoutNoteConfiguration : IEntityTypeConfiguration<WorkoutNote>
{
  public void Configure(EntityTypeBuilder<WorkoutNote> builder)
  {
    builder.Property(x => x.Id).ValueGeneratedNever();
  }
}

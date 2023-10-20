using Application.Workouts.DTOs;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper]
public partial class WorkoutMapper
{
  public partial WorkoutDto WorkoutToDto(Workout workout);
  public partial Workout DtoToWorkout(WorkoutDto workoutDto);
  public partial WorkoutNoteDto WorkoutNoteToDto(WorkoutNote workoutNoteDto);
  public partial WorkoutNote DtoToWorkoutNote(WorkoutNoteDto noteDto);
}

using Application.Mappers;
using Application.Workouts.DTOs;
using Domain;
using Domain.Repositories;
using MediatR;

namespace Application.Workouts.Commands;

public record CreateWorkoutNoteCommand(Guid WorkoutId, WorkoutNoteDto WorkoutNote) : IRequest;

public class CreateWorkoutNoteCommandHandler : IRequestHandler<CreateWorkoutNoteCommand>
{
  private readonly IWorkoutRepository _workoutRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly WorkoutMapper _workoutMapper;

  public CreateWorkoutNoteCommandHandler(IWorkoutRepository workoutRepository, IUnitOfWork unitOfWork)
  {
    _workoutRepository = workoutRepository;
    _unitOfWork = unitOfWork;
    _workoutMapper = new WorkoutMapper();
  }

  public async Task Handle(CreateWorkoutNoteCommand request, CancellationToken cancellationToken)
  {
    var note = _workoutMapper.DtoToWorkoutNote(request.WorkoutNote);

    await _workoutRepository.AddNoteAsync(request.WorkoutId, note, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
  }
}

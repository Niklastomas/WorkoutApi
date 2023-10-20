using Application.Base;
using Domain;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Workouts.Commands;

public record DeleteWorkoutCommand(Guid Id) : IRequest;

public class DeleteWorkoutCommandHandler : BaseHandler<Workout>, IRequestHandler<DeleteWorkoutCommand>
{
  public DeleteWorkoutCommandHandler(IWorkoutRepository workoutRepository, IUnitOfWork unitOfWork) : base(workoutRepository, unitOfWork)
  { }

  public async Task Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
  {
    await _repository.DeleteAsync(request.Id, cancellationToken);

    await _unitOfWork.SaveChangesAsync(cancellationToken);
  }
}

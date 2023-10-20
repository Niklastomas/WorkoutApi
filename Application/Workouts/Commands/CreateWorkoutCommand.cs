using Application.Auth;
using Application.Base;
using Application.Mappers;
using Application.Models;
using Application.Workouts.DTOs;
using Domain;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Workouts.Commands;

public record CreateWorkoutCommand(WorkoutDto WorkoutDto) : IRequest<ResponseData<WorkoutDto>>;

public class CreateWorkoutCommandHandler : BaseHandler<Workout>, IRequestHandler<CreateWorkoutCommand, ResponseData<WorkoutDto>>
{
  private readonly IUserService _userService;
  private readonly WorkoutMapper _workoutMapper;

  public CreateWorkoutCommandHandler(
    IWorkoutRepository workoutRepository,
    IUnitOfWork unitOfWork,
    IUserService userService) : base(workoutRepository, unitOfWork)
  {
    _userService = userService;
    _workoutMapper = new WorkoutMapper();
  }

  public async Task<ResponseData<WorkoutDto>> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
  {

    var userId = _userService.GetUserId();

    if (userId is null)
    {
      return new ResponseData<WorkoutDto>($"Could not find userId with id: {userId}");
    }

    var workoutDto = request.WorkoutDto;
    var workout = _workoutMapper.DtoToWorkout(workoutDto);
    workout.SetUserId(userId.Value);

    workout = await _repository.CreateAsync(workout, cancellationToken);
    workoutDto.Id = workout.Id;

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    if (workout is null)
    {
      return new ResponseData<WorkoutDto>($"Failed to create workout.");
    }

    return new ResponseData<WorkoutDto>(workoutDto);
  }
}


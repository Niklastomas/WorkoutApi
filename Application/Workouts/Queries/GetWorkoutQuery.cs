using Application.Auth;
using Application.Mappers;
using Application.Models;
using Application.Workouts.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Workouts.Queries;

public record GetWorkoutQuery(Guid Id) : IRequest<ResponseData<WorkoutDto>>;

public class GetWorkoutQueryHandler : IRequestHandler<GetWorkoutQuery, ResponseData<WorkoutDto>>
{
  private readonly IWorkoutRepository _workoutRepository;
  private readonly IUserService _userService;
  private readonly WorkoutMapper _workoutMapper;

  public GetWorkoutQueryHandler(IWorkoutRepository workoutRepository, IUserService userService)
  {
    _workoutRepository = workoutRepository;
    _userService = userService;
    _workoutMapper = new WorkoutMapper();
  }

  public async Task<ResponseData<WorkoutDto>> Handle(GetWorkoutQuery request, CancellationToken cancellationToken)
  {
    var userId = _userService.GetUserId();

    if (userId is null)
    {
      return new("Failed to get user id");
    }

    var workout = await _workoutRepository.GetByIdAsync(request.Id, userId.Value, cancellationToken);

    if (workout is null)
    {
      return new($"Workout with id {request.Id} not found.");
    }

    return new(_workoutMapper.WorkoutToDto(workout));
  }
}

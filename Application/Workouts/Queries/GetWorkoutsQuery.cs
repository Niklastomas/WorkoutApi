using Application.Auth;
using Application.Mappers;
using Application.Models;
using Application.Workouts.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Workouts.Queries;


public record GetWorkoutsQuery() : IRequest<ResponseData<IEnumerable<WorkoutDto>>>;

public class GetWorkoutsQueryHandler : IRequestHandler<GetWorkoutsQuery, ResponseData<IEnumerable<WorkoutDto>>>
{
  private readonly IWorkoutRepository _workoutRepository;
  private readonly IUserService _userService;
  private readonly WorkoutMapper _workoutMapper;

  public GetWorkoutsQueryHandler(
    IWorkoutRepository repository,
    IUserService userService)
  {
    _workoutRepository = repository;
    _userService = userService;
    _workoutMapper = new WorkoutMapper();
  }

  public async Task<ResponseData<IEnumerable<WorkoutDto>>> Handle(GetWorkoutsQuery request, CancellationToken cancellationToken)
  {
    var userId = _userService.GetUserId();

    if (userId is null)
    {
      return new("Failed to get user id");
    }

    var workouts = await _workoutRepository.GetAsync(userId.Value, cancellationToken);

    return new(workouts.Select(x => _workoutMapper.WorkoutToDto(x)).ToList());
  }
}

using Application.Workouts.Commands;
using Application.Workouts.DTOs;
using Application.Workouts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

public static class WorkoutEndpoints
{

  public static WebApplication AddWorkoutEndpoints(this WebApplication app)
  {

    var baseUrl = "/api/workouts";
    var urlWithId = baseUrl + "/{id:Guid}";


    app.MapGet(baseUrl, async (ISender sender) =>
    {
      var response = await sender.Send(new GetWorkoutsQuery());

      return Results.Ok(response.Data);

    })
    .RequireAuthorization();

    app.MapGet(urlWithId, async (ISender sender, [FromRoute] Guid id) =>
    {
      var response = await sender.Send(new GetWorkoutQuery(id));

      if (response.Success)
      {
        return Results.Ok(response.Data);
      }

      return Results.NotFound();

    })
    .RequireAuthorization();

    app.MapPost(baseUrl, async (
      ISender sender,
      [FromBody] WorkoutDto workoutDto) =>
    {
      var response = await sender.Send(new CreateWorkoutCommand(workoutDto));

      if (response.Success && response.Data is not null)
      {
        return Results.Created($"{baseUrl}/{response.Data.Id}", response.Data);
      }

      return Results.BadRequest(response.ErrorMessage);
    })
    .RequireAuthorization();

    app.MapDelete(urlWithId, async (ISender sender, [FromRoute] Guid id) =>
    {
      await sender.Send(new DeleteWorkoutCommand(id));

      return Results.NoContent();
    })
    .RequireAuthorization();

    app.MapPost(urlWithId + "/notes", async (ISender sender, [FromRoute] Guid id, [FromBody] WorkoutNoteDto workoutNote) =>
    {
      await sender.Send(new CreateWorkoutNoteCommand(id, workoutNote));
      return Results.NoContent();
    });

    return app;
  }
}

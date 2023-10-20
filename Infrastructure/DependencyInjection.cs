using Application.Auth;
using Domain;
using Domain.Repositories;
using Infrastructure.Auth;
using Infrastructure.Auth.Models;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
  {


    services.AddDbContext<WorkoutDbContext>(options =>
    {
      options.UseNpgsql(config.GetConnectionString(DbContextSettings.WorkoutDbContext));
    });
    services.AddDbContext<IdentityDbContext>(options =>
    {
      options.UseNpgsql(config.GetConnectionString(DbContextSettings.IdentityDbContext));
    });

    services.AddIdentityCore<AppUser>()
      .AddEntityFrameworkStores<IdentityDbContext>();

    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<IWorkoutRepository, WorkoutRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserService, UserService>();

    return services;
  }

}


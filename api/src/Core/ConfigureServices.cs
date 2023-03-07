using Microsoft.Extensions.Configuration;
using Core.Abstractions.Services.Auth;
using Core.Services.Authentication;
using Core.Services.Workouts;
using Core.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Core;
public static class ConfigureServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<RegisterValidator>();
        services.AddTransient<LoginValidator>();

        services.AddTransient<IMuscleService, MuscleService>();
        services.AddTransient<IMuscleGroupService, MuscleGroupService>();
        services.AddTransient<IExerciseService, ExerciseService>();
        //services.AddTransient<IWorkoutService, WorkoutService>();
        //services.AddTransient<IWorkoutRoutineService, WorkoutRoutineService>();
        //services.AddTransient<IWorkoutBuilderService, WorkoutBuilderService>();

        return services;
    }
}

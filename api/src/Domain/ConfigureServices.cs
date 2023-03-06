using Microsoft.Extensions.Configuration;
using Core.Services.WorkoutsServices;
using Core.Abstractions.Services.Auth;
using Core.Services.Authentication;
using Core.Application.Validators;

namespace Microsoft.Extensions.DependencyInjection;
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

using Microsoft.Extensions.Configuration;
using Infrastructure.Context;
using Core.Abstractions.Context;
using Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<IEquipmentRepository, EquipmentRepository>();
        services.AddTransient<IMuscleRepository, MuscleRepository>();
        services.AddTransient<IMuscleGroupRepository, MuscleGroupRepository>();
        services.AddTransient<IExerciseRepository, ExerciseRepository>();
        services.AddTransient<IWorkoutRepository, WorkoutRepository>();
        services.AddTransient<IWorkoutRoutineRepository, WorkoutRoutineRepository>();
        return services;
    }
}

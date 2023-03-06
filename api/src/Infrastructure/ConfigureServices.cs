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
        services.AddTransient<IExerciseRepository, ExerciseRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IMuscleRepository, MuscleRepository>();
        return services;
    }
}

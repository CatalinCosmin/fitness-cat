using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.WebHost.UseUrls("https://localhost:7061");
        // Configure services
        ConfigureServices(builder, builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }

    private static void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
    {
        services.AddSwaggerGen();

        services.AddDbContext<DataContext>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<RegisterValidator>();
        services.AddTransient<LoginValidator>();

        services.AddTransient<IMuscleService, MuscleService>();
        services.AddTransient<IMuscleGroupService, MuscleGroupService>();
        services.AddTransient<IExerciseService, ExerciseService>();
        services.AddTransient<IWorkoutService, WorkoutService>();
        services.AddTransient<IWorkoutRoutineService, WorkoutRoutineService>();
        services.AddTransient<IWorkoutBuilderService, WorkoutBuilderService>();

        services.AddControllers();

        services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            {
                // Allow multiple methods
                builder.WithMethods("GET", "POST", "PATCH", "DELETE")
                    .WithHeaders(
                        HeaderNames.Accept,
                        HeaderNames.ContentType,
                        HeaderNames.Authorization)
                    .SetIsOriginAllowed(origin =>
                    {
                        if (string.IsNullOrWhiteSpace(origin)) return false;
                        // Only add this to allow testing with localhost, remove this line in production!
                        if (origin.ToLower().Contains("localhost:3000")) return true;
                        // Insert your production domain here.
                        if (origin.ToLower().StartsWith("https://someone@example.com")) return true;
                        return false;
                    });
            })
);

        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            string key = builder.Configuration["JWT:Key"]!;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false
            };
        });

        services.AddAuthorization();
    }
}
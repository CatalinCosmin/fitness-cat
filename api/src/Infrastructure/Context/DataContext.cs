using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration["con"]);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(x => x.ID);
            builder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
            builder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();

            builder.Entity<Exercise>()
                .HasKey(x => x.ID);
            builder.Entity<Equipment>()
                .HasKey(x => x.ID);
            builder.Entity<Workout>()
                .HasKey(x => x.ID);
            builder.Entity<MuscleGroup>()
                .HasKey(x => x.ID);
            builder.Entity<WorkoutRoutine>()
                .HasKey(x => x.ID);

            builder.Entity<Exercise>()
                .HasMany(e => e.MuscleGroups)
                .WithMany(m => m.Exercises)
                .UsingEntity(j => j.ToTable("ExercisesMuscleGroups"));

            builder.Entity<Exercise>()
                .HasMany(e => e.Equipments)
                .WithMany(x => x.Exercises)
                .UsingEntity(j => j.ToTable("ExercisesEquipments"));

            builder.Entity<Workout>()
                .HasMany(e => e.Exercises)
                .WithMany(x => x.Workouts)
                .UsingEntity(j => j.ToTable("WorkoutsExercises"));

            builder.Entity<WorkoutRoutine>()
                .HasMany(e => e.Workouts)
                .WithMany(w => w.WorkoutRoutine)
                .UsingEntity(j => j.ToTable("WorkoutRoutinesWorkouts"));

            builder.Entity<Workout>()
                .HasOne(w => w.Owner)
                .WithMany(u => u.Workouts)
                .HasForeignKey("workout_owner");

            builder.Entity<WorkoutRoutine>()
                .HasOne(w => w.Owner)
                .WithMany(u => u.WorkoutRoutines)
                .HasForeignKey("workoutroutine_owner");

            builder.Entity<MuscleGroup>()
                .HasMany(m => m.Muscles)
                .WithMany(mg => mg.MuscleGroups)
                .UsingEntity(j => j.ToTable("MusclesMuscleGroups"));

        }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutRoutine> WorkoutRoutines { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
    }
}

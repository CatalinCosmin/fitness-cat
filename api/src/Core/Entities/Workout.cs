using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Workout : IWorkout
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly CreationDate { get; set; }
        public int AccesibilityLevel { get; set; } = 0;

        public List<IExercise> Exercises { get; set; } = new();
        public IUser Owner { get; set; } = new User();
        public List<IWorkoutRoutine> WorkoutRoutine { get; set; } = new();
    }
}

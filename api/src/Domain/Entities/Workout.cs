using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Workout : IWorkout
    {
        public Guid ID { get; set; }
        public DateOnly CreationDate { get; set; }
        public int AccesibilityLevel { get; set; } = 0;

        public List<IExercise> Exercises { get; set; } = new();
        public IUser? Owner { get; set; } = null;
        public List<IWorkoutRoutine> WorkoutRoutine { get; set; } = new();
    }
}

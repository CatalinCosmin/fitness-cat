using System.ComponentModel.DataAnnotations;

namespace Core.Abstractions.Entities
{
    public interface IWorkout
    {
        [Key, Required]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public int AccesibilityLevel { get; set; }

        public List<IExercise> Exercises { get; set; }
        public IUser Owner { get; set; }
        public List<IWorkoutRoutine> WorkoutRoutine { get; set; }
    }
}

using Core.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Workout
    {
        [Key, Required]
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly CreationDate { get; set; }
        public int AccesibilityLevel { get; set; } = 0;

        public List<Exercise> Exercises { get; set; } = new();
        public User Owner { get; set; } = new();
        public List<WorkoutRoutine> WorkoutRoutine { get; set; } = new();
    }
}

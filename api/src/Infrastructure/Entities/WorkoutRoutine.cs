using Core.Abstractions.Entities;

namespace Infrastructure.Entities
{
    public class WorkoutRoutine
    {
        public Guid ID { get; set; }
        public int AccesibilityLevel { get; set; }
        public User Owner { get; set; } = new();
        public List<Workout> Workouts { get; set; } = new();
    }
}

namespace Core.Entities
{
    public class WorkoutRoutine : IWorkoutRoutine
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AccesibilityLevel { get; set; }
        public IUser Owner { get; set; } = new User();
        public List<IWorkout> Workouts { get; set; } = new();
        public string Description { get; set; } = string.Empty;
    }
}

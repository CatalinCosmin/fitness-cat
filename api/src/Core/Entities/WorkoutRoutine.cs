namespace Core.Entities
{
    public class WorkoutRoutine : IWorkoutRoutine
    {
        public Guid ID { get; set; }
        public int AccesibilityLevel { get; set; }
        public IUser Owner { get; set; } = new User();
        public List<IWorkout> Workouts { get; set; } = new();
    }
}

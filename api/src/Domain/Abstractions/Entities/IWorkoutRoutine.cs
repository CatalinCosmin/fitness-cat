namespace Core.Abstractions.Entities
{
    public interface IWorkoutRoutine
    {
        public Guid ID { get; set; }
        public int AccesibilityLevel { get; set; }
        public IUser Owner { get; set; }
        public List<IWorkout> Workouts { get; set; }
    }
}

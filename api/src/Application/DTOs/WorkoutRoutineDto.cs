namespace Application.DTOs
{
    public class WorkoutRoutineDto
    {
        public Guid ID { get; set; }
        public int AccesibilityLevel { get; set; }
        public List<WorkoutDto> Workouts { get; set; } = new List<WorkoutDto>();
    }
}

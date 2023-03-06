namespace Application.DTOs
{
    public class WorkoutDto
    {
        public Guid ID { get; set; }
        public DateOnly CreationDate { get; set; }
        public int AccesibilityLevel { get; set; } = 0;

        public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
    }
}

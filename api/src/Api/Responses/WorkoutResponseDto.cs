using Core.Abstractions.Entities;

namespace Api.Responses
{
    public class WorkoutResponseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ExerciseResponseDto> Exercises { get; set; } = new List<ExerciseResponseDto>();
    }
}

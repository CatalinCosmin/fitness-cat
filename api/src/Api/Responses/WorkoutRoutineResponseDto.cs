using Core.Abstractions.Entities;

namespace Api.Responses
{
    public class WorkoutRoutineResponseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<WorkoutResponseDto> Workouts { get; set; } = new List<WorkoutResponseDto>();
    }
}

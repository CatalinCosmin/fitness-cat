using Core.Abstractions.Entities;

namespace Api.Responses
{
    public class ExerciseResponseDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MuscleGroupResponseDto> MuscleGroups { get; set; } = new List<MuscleGroupResponseDto>();
    }
}

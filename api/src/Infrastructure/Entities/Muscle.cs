using Core.Abstractions.Entities;

namespace Infrastructure.Entities
{
    public class Muscle
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Exercise> Exercises { get; set; } = new();
        public List<MuscleGroup> MuscleGroups { get; set; } = new();
    }
}

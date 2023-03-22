using Core.Abstractions.Entities;

namespace Infrastructure.Entities
{
    public class Exercise
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Difficulty { get; set; }

        public List<Equipment> Equipments { get; set; } = new();
        public List<MuscleGroup> MuscleGroups { get; set; } = new();
        public List<Muscle> Muscles { get; set; } = new();
        public List<Workout> Workouts { get; set; } = new();
    }
}

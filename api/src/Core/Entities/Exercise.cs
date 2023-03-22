namespace Core.Entities
{
    public class Exercise : IExercise
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Difficulty { get; set; }

        public List<IEquipment> Equipments { get; set; } = new();
        public List<IMuscleGroup> MuscleGroups { get; set; } = new();
        public List<IMuscle> Muscles { get; set; } = new();
        public List<IWorkout> Workouts { get; set; } = new();
    }
}

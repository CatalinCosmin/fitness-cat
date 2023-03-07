namespace Core.Entities
{
    public class Muscle : IMuscle
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<IExercise> Exercises { get; set; } = new();
        public List<IMuscleGroup> MuscleGroups { get; set; } = new();
    }
}

namespace Core.Entities
{
    public class MuscleGroup : IMuscleGroup
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<IExercise> Exercises { get; set; } = new();
        public List<IMuscle> Muscles { get; set; } = new();
    }
}

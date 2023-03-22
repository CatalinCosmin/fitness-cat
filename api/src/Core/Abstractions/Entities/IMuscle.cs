namespace Core.Abstractions.Entities
{
    public interface IMuscle
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<IExercise> Exercises { get; set; }
        public List<IMuscleGroup> MuscleGroups { get; set; }
    }
}

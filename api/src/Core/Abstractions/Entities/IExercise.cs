namespace Core.Abstractions.Entities
{
    public interface IExercise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }

        public List<IEquipment> Equipments { get; set; }
        public List<IMuscleGroup> MuscleGroups { get; set; }
        public List<IMuscle> Muscles { get; set; }
        public List<IWorkout> Workouts { get; set; }
    }
}

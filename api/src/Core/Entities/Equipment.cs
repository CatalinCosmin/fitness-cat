namespace Core.Entities
{
    public class Equipment : IEquipment
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<IExercise> Exercises { get; set; } = new();

    }
}

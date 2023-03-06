namespace Infrastructure.Entities
{
    public class Equipment
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

    }
}

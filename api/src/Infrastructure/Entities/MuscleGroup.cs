using Core.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class MuscleGroup
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Exercise> Exercises { get; set; } = new();
        public List<Muscle> Muscles { get; set; } = new();
    }
}

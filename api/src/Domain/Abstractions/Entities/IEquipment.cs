using System.ComponentModel.DataAnnotations;

namespace Core.Abstractions.Entities
{
    public interface IEquipment
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<IExercise> Exercises { get; set; }
    }
}

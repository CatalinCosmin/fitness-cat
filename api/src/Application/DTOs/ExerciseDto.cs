namespace Application.DTOs
{
    public class ExerciseDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Difficulty { get; set; }
        public List<MuscleGroupDto> MuscleGroups { get; set; } = new List<MuscleGroupDto>();
        public List<MuscleDto> Muscles { get; set; } = new List<MuscleDto>();
        public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();
    }
}

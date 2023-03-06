//using Domain.Common.Entities;
//using Application.DTOs;

//namespace Infrastructure.Extensions
//{
//    public static class EquipmentExtensions
//    {
//        public static List<EquipmentDto> ToDtos(this List<IEquipment> entities)
//        {
//            return entities.Select(ToDto).ToList();
//        }

//        public static EquipmentDto ToDto(this IEquipment entity)
//        {
//            return new EquipmentDto
//            {
//                ID = entity.ID,
//                Name = entity.Name
//            };
//        }
//    }
//}

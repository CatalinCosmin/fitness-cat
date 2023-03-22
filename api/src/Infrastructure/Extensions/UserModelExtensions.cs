using Core.Abstractions.Entities;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class UserModelExtensions
    {
        public static User ToEntity(this IUser entity)
        {
            return new User
            {
                ID= entity.ID,
                AccountCreationDate= entity.AccountCreationDate,
                BirthDate= entity.BirthDate,
                Email= entity.Email,
                isVerified = entity.isVerified,
                LastAuthenticationDate= entity.LastAuthenticationDate,
                Password= entity.Password,
                Username= entity.Username,
                WorkoutRoutines = new List<WorkoutRoutine>(),
                Workouts = new List<Workout>()
            };
        }
    }
}

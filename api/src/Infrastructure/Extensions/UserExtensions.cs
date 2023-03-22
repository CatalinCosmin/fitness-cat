using Core.Abstractions.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class UserExtensions
    {
        internal static IUser ToModel(this Infrastructure.Entities.User entity)
        {
            return new Core.Entities.User
            {
                ID = entity.ID,
                AccountCreationDate= entity.AccountCreationDate,
                BirthDate= entity.BirthDate,
                Email= entity.Email,
                isVerified = entity.isVerified,
                LastAuthenticationDate= entity.LastAuthenticationDate,
                Password= entity.Password,
                Username= entity.Username,
                WorkoutRoutines = entity.WorkoutRoutines.ToModelsSimple(),
                Workouts = entity.Workouts.ToModelsSimple()
            };
        }

        internal static List<IUser> ToModels(this List<Infrastructure.Entities.User> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

        internal static IUser ToModelSimple(this Infrastructure.Entities.User entity)
        {
            return new Core.Entities.User
            {
                ID = entity.ID,
                AccountCreationDate = entity.AccountCreationDate,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                isVerified = entity.isVerified,
                LastAuthenticationDate = entity.LastAuthenticationDate,
                Password = entity.Password,
                Username = entity.Username
            };
        }

        internal static List<IUser> ToModelsSimple(this List<Infrastructure.Entities.User> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }

    }
}

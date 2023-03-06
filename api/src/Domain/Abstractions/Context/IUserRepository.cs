
using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IUserRepository
    {
        IUser? GetUser(Func<IUser, bool> predicate);
        IUser? GetUserById(Guid id);
    }
}
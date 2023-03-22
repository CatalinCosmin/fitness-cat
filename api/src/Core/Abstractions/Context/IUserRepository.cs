
using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IUserRepository
    {
        Task<bool> AddUser(IUser entity);
        Task<IUser?> GetUser(string? username = null, string? email = null, Guid? id = null);
        IUser? GetUserById(Guid id);
    }
}
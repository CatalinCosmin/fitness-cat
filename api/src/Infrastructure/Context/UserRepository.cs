using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Infrastructure.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(IUser entity)
        {
            _context.Users.Add(entity.ToEntity());
            var success = await _context.SaveChangesAsync();

            return success > 0;
        }

        public IUser? GetUser(Func<IUser, bool> predicate)
        {
            return _context.Users
                .Where((Func<Entities.User, bool>)predicate)
                .FirstOrDefault()?.ToModel();
        }

        public async Task<IUser?> GetUser(string? username = null, string? email = null, Guid? id = null)
        {
            var query = _context.Users.AsQueryable();
            if (username is not null)
            {
                query = query.Where(u => u.Username == username);
            }
            if (email is not null)
            {
                query = query.Where(u => u.Email == email);
            }
            if (id is not null)
            {
                query = query.Where(u => u.ID == id);
            }
            var user = await query.FirstOrDefaultAsync();
            return user?.ToModel();
        }

        public IUser? GetUserById(Guid id)
        {
            return _context.Users
                .Where(u => u.ID == id)
                .FirstOrDefault()?.ToModel();
        }
    }
}

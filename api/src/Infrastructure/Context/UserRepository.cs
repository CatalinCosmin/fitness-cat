using Core.Abstractions.Context;
using Core.Abstractions.Entities;
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

        public IUser? GetUser(Func<IUser, bool> predicate)
        {
            return _context.Users
                .Where((Func<Entities.User, bool>)predicate)
                .FirstOrDefault()?.ToModel();
        }

        public IUser? GetUserById(Guid id)
        {
            return _context.Users
                .Where(u => u.ID == id)
                .FirstOrDefault()?.ToModel();
        }
    }
}

using Core.Abstractions.Context;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, IExerciseRepository exercises, IUserRepository users)
        {
            _dataContext = dataContext;
            Exercises = exercises;
            Users = users;
        }

        public IExerciseRepository Exercises { get; set; }
        
        public IUserRepository Users { get; set; }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

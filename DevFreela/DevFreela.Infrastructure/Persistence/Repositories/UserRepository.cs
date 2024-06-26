﻿using DevFreela.Application.Repositories;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> GetUserAsync(string email, string passwordHash)
        {
            return _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

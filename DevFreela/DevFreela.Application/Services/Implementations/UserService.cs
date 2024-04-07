using DevFreela.Application.InputModels.User;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel userInputModel)
        {
            var user = new User(userInputModel.FullName, userInputModel.Email, userInputModel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;

            //return 1;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(user.FullName, user.Email);

            return userViewModel;

            //return new UserViewModel("", "");
        }
    }
}

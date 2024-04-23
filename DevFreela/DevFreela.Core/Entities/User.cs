using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;
            IsActive = true;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime BirthDate { get; private set; }
        public bool IsActive { get; private set; }
    }
}

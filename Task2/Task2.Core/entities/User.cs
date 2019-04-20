using System;

namespace Task2.Core.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(string login, string password, Roles role)
        {
            Id = Guid.NewGuid();
            Login = login;
            Password = password;
            Role = role;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
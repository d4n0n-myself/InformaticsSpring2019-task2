using System;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Domain
{
    public class UserDomainService
    {
        private readonly IUserRepository _repos;

        public UserDomainService(IUserRepository repos)
        {
            _repos = repos;
        }

        public bool Add(string login, string password, Roles role)
        {
            return _repos.Add(login, password, role);
        }

        public bool Delete(User user)
        {
            return _repos.Delete(user);
        }

        public User Get(string login)
        {
            return _repos.Get(login);
        }

        public User Get(Guid id)
        {
            return _repos.Get(id);
        }

        public bool CheckPassword(string login, string password)
        {
            return _repos.CheckPassword(login, password);
        }

        public bool ContainUser(string login)
        {
            return _repos.ContainUser(login);
        }

        public bool ChangeRole(Guid id, Roles newRole)
        {
            return _repos.ChangeRole(id, newRole);
        }
    }
}
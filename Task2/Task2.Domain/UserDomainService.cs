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

        public void Add(string login, string password, Roles role) => _repos.Add(login, password, role);
        public void ChangeRole(Guid id, Roles newRole) => _repos.ChangeRole(id, newRole);
        public bool CheckPassword(string login, string password) => _repos.CheckPassword(login, password);
        public bool ContainUser(string login) => _repos.Contains(login);
        public void Delete(User user) => _repos.Delete(user);
        public User Get(string login) => _repos.Get(login);

        [Obsolete]
        public User Get(Guid id) => _repos.Get(id);
    }
}
using System;
using Task2.Core.Entities;

namespace Task2.Infrastructure.ReposInterfaces
{
    public interface IUserRepository
    {
        void Add(string login, string password, Roles role);
        void Delete(User user);
        User Get(string login);
        User Get(Guid id);
        bool CheckPassword(string login, string password);
        bool Contains(string login);
        void ChangeRole(Guid id, Roles newRole);
    }
}
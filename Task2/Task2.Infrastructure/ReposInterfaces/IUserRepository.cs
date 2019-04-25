using System;
using Task2.Core.Entities;

namespace Task2.Infrastructure.ReposInterfaces
{
    public interface IUserRepository
    {
        bool Add(string login, string password, Roles role);
        bool Delete(User user);
        User Get(string login);
        User Get(Guid id);
        bool CheckPassword(string login, string password);
        bool ContainUser(string login);
        bool ChangeRole(Guid id, Roles newRole);
    }
}
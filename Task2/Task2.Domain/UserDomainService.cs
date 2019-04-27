using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public void Add(string login, string password, Roles role)
        {
            var encryptedPass = CypherPassword(password);
            _repos.Add(login, encryptedPass, role);
        }

        public void ChangeRole(string login, Roles newRole) => _repos.ChangeRole(login, newRole);

        public bool CheckPassword(string login, string password)
        {
            var encryptedReceivedPassword = CypherPassword(password);
            var user = _repos.Get(login);
            if (!user.Password.SequenceEqual(encryptedReceivedPassword))
                throw new ArgumentException($"Invalid credentials on {login}");
            return true;
        }

        public bool ContainUser(string login) => _repos.Contains(login);
        public void Delete(User user) => _repos.Delete(user);
        public User Get(string login) => _repos.Get(login);

        private string CypherPassword(string password)
        {
            var bytes = Encoding.Unicode.GetBytes(password);
            var csp = new MD5CryptoServiceProvider();
            var byteHash = csp.ComputeHash(bytes);
            return byteHash.Aggregate(string.Empty, (current, b) => current + $"{b:x2}");
        }
    }
}
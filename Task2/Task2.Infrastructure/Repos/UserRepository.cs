using System;
using System.Linq;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Infrastructure.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(string login, string password, Roles role)
        {
            if (_context.Users.Any(u => u.Login == login))
                throw new ArgumentException("User already in database!");
            _context.Users.Add(new User(login, password, role));
            _context.SaveChanges();
        }

        public void ChangeRole(string login, Roles newRole)
        {
            var user = _context.Users.First(u => u.Login == login);
            user.Role = newRole;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool Contains(string login) => _context.Users.Any(u => u.Login.Equals(login));

        public void Delete(User user)
        {
            var userForDeleting = _context.Users.FirstOrDefault(u => u.Id.Equals(user.Id)) ??
                                  throw new ArgumentNullException(nameof(user),
                                      "No user in database!");
            _context.Users.Remove(userForDeleting);
            _context.SaveChanges();
        }

        public User Get(string login) => _context.Users.FirstOrDefault(u => u.Login.Equals(login));
        public User Get(Guid id) => _context.Users.FirstOrDefault(u => u.Id.Equals(id));
    }
}
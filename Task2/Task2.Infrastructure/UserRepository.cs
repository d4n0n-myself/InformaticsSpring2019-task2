using System;
using System.Linq;
using Task2.Core.entities;

namespace Task2.Infrastructure
{
    public class UserRepository
    {
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public UserRepository()
        {
            _context = new ApplicationContext();
        }

        public bool Add(string login, string password, Roles role)
        {
            try
            {
                if (!_context.Users.Any(u => u.Login == login))
                {
                    _context.Users.Add(new User(login, password, role));
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(User user)
        {
            try
            {
                var userForDeleting = _context.Users.First(u => u.Id.Equals(user.Id));
                _context.Users.Remove(userForDeleting);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public User Get(string login) => _context.Users.First(u => u.Login.Equals(login));
        public User Get(Guid id) => _context.Users.First(u => u.Id.Equals(id));
        
        public bool CheckPassword(string login, string password) =>
            _context.Users.First(u => u.Login == login).Password.Equals(password);
        
        public bool ContainUser(string login) => _context.Users.Any(u => u.Login.Equals(login));


        private readonly ApplicationContext _context;
    }
}
using Library3.Contracts;
using Library3.Infrastructure;
using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _context =new AppDbContext();

        public int Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
                throw new Exception("user not found");
        }

        public List<User> GetAll()
        {
            var users=_context.Users.ToList();
            return users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            else
                throw new Exception("user not found");
        }

        public void Update(User user)
        {
            var user1 = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (user1 != null)
            {
                user1.FirstName=user.FirstName;
                user1.LastName=user.LastName;
                user1.Email=user.Email;
                user1.Username=user.Username;
                user1.Password=user.Password;
                user1.Role=user.Role;
            }
            _context.SaveChanges();
        }
    }
}

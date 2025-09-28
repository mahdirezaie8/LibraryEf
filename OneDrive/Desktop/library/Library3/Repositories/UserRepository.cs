using Library3.Contracts;
using Library3.Dto;
using Library3.Infrastructure;
using Library3.ntts;
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
                user1.PenaltyAmount = user.PenaltyAmount;
            }
            _context.SaveChanges();
        }
        public List<UserDto> GetAllUser()
        {
            var users=_context.Users.Select(x => new UserDto
            {
                Id = x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Username=x.Username,
                PenaltyAmount=x.PenaltyAmount,
            }).ToList();
            return users;
        }
        public UserDto GetUser(int userid)
        {
            var user = _context.Users.Select(x=>new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Username = x.Username,
                PenaltyAmount = x.PenaltyAmount,
            }).FirstOrDefault(x=>x.Id == userid);
            return user;
        }

        
    }
}

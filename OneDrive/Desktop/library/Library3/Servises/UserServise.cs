using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.Enums;
using Library3.ntts;
using Library3.Repositories;
namespace Library3.Servises
{
    public class UserServise: IUserServise
    {
        IUserRepository _userRepository=new UserRepository();
        public void Register(string username, string password, string firstname, string lastname,string email,RoleEnum role)
        {
            var user=_userRepository.GetAll().Find(x=>x.Username==username);
            if (user != null)
            {
                throw new Exception("username already exists");
            }
            if (password.Length > 5 && username.Length > 5&&email.EndsWith("@gmail.com"))
            {
                User user1 = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    FirstName = firstname,
                    LastName = lastname,
                    Role = role
                };
                _userRepository.Create(user1);
            }
            else
                throw new Exception("username and password longer than 5 characters and the last letter of the email should end whith {@gmail.com}");
        }
        public User? Login(string username, string password)
        {
            var user=_userRepository.GetAll().Find(x =>x.Username==username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
                else
                    throw new Exception("password is false");
            }
            else
                throw new Exception("username not found");
        }
        public UserDto ShowProfile(User user)
        {
            var newuser=_userRepository.GetUser(user.Id);
            return newuser;
        }
        public List<UserDto> ShowAllUser()
        {
            var alluser= _userRepository.GetAllUser();
            return alluser;
        }

    }
}

using Library3.Dto;
using Library3.Enums;
using Library3.ntts;
namespace Library3.Contracts.IServices
{
    public interface IUserServise
    {
        public void Register(string username, string password, string firstname, string lastname, string email, RoleEnum role);
        public User? Login(string username, string password);
        public UserDto ShowProfile(User user);
        public List<UserDto> ShowAllUser();
    }
}

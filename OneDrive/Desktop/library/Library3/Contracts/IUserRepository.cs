using Library3.Dto;
using Library3.ntts;
namespace Library3.Contracts
{
    public interface IUserRepository
    {
        int Create(User user);
        void Update(User user);
        List<User> GetAll();
        User GetById(int id);
        void Delete(int id);
        public List<UserDto> GetAllUser();
        public UserDto GetUser(int userid);
    }
}

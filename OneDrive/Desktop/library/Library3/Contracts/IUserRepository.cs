using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts
{
    public interface IUserRepository
    {
        int Create(User user);
        void Update(User user);
        List<User> GetAll();
        User GetById(int id);
        void Delete(int id);
    }
}

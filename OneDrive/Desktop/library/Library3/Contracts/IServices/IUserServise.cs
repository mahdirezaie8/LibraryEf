using Library3.Enums;
using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts.IServices
{
    public interface IUserServise
    {
        public void Register(string username, string password, string firstname, string lastname, string email, RoleEnum role);
        public User? Login(string username, string password);
    }
}

using Library3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.ntts
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public RoleEnum Role { get; set; }
        public List<BorrowedBook> BorrowedBooks { get; set; } = [];
        public List<Review> reviews { get; set; } = [];


    }
}

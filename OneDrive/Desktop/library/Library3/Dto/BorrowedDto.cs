using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Dto
{
    public class BorrowedDto
    {
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Bookname { get; set; }
    }
}

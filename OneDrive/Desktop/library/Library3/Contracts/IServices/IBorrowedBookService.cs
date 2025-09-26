using Library3.Dto;
using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts.IServices
{
    public interface IBorrowedBookService
    {
        public void CreateBorrowed(int bookid, User user);
        public List<BorrowedDto> GetAllBorrowedBooksUser(User user);
    }
}

using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Servises
{
    public class BorrowedBookService: IBorrowedBookService
    {
        IBorrowedBook borrowedBookRepository = new BorrowedBookRepository();
        IUserRepository UserRepository = new UserRepository();
        IBookRepository BookRepository = new BookRepository();
        public void CreateBorrowed(int bookid,User user)
        {
            var book=BookRepository.GetById(bookid);
            var oldbookborrowd=borrowedBookRepository.GetBorrowedBookUser(bookid,user);
            if (oldbookborrowd==null)
            {
                var borrowedBook = new BorrowedBook
                {
                    BookId = book.Id,
                    UserId = user.Id,
                    DateTime = DateTime.Now,
                };
                borrowedBookRepository.Create(borrowedBook);
            }
            else
                throw new Exception("this book borrowed by you");
        }
        public List<BorrowedDto> GetAllBorrowedBooksUser(User user)
        {
            var borroweduserid= borrowedBookRepository.GetAllBorrowedBooksUser(user.Id);
            if(borroweduserid.Count()>0)
            {
                return borroweduserid;
            }
            else
                throw new Exception("you dont borrow a book");
        }
    }
}

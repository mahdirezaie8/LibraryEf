using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;
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
                    CreatAt = DateTime.Now,
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
        public void ReturnBook(int bookid, int userid)
        {
            var user=UserRepository.GetById(userid);
            var borrowed = borrowedBookRepository.GetBorrowedBookUser(bookid, user);
            if (borrowed != null)
            {
                if (borrowed.ReturnDate==null)
                {
                    borrowed.ReturnDate = DateTime.Now;
                    borrowedBookRepository.Update(borrowed);
                    var firstday = borrowed.CreatAt;
                    var lastday=borrowed.ReturnDate;
                    TimeSpan diff=(lastday-firstday).Value;
                    int days = diff.Days;
                   var fine= borrowedBookRepository.GetFine(days);
                    if(user.PenaltyAmount==null)
                    {
                        user.PenaltyAmount = fine;
                        UserRepository.Update(user);
                    }
                    else
                    {
                        user.PenaltyAmount = user.PenaltyAmount + fine;
                        UserRepository.Update(user) ;
                    }
                }
                else 
                    throw new Exception("this book has been returned");
            }
            else
                throw new Exception("this borrowed not found");
        }
    }
}

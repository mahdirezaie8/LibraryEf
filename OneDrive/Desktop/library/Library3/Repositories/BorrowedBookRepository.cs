using Library3.Contracts;
using Library3.Dto;
using Library3.Infrastructure;
using Library3.ntts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Repositories
{
    public class BorrowedBookRepository: IBorrowedBook
    {
        AppDbContext _context = new AppDbContext();
        public int Create(BorrowedBook borrowedBook)
        {
            _context.BorrowedBooks.Add(borrowedBook);
            _context.SaveChanges();
            return borrowedBook.Id;
        }

        public void Delete(int id)
        {
            var BorrowedBook = _context.BorrowedBooks.FirstOrDefault(x => x.Id == id);
            if (BorrowedBook != null)
            {
                _context.BorrowedBooks.Remove(BorrowedBook);
                _context.SaveChanges();
            }
            throw new Exception("BorrowedBook not found");
        }

        public BorrowedBook GetById(int id)
        {
            var BorrowedBook = _context.BorrowedBooks.FirstOrDefault(x => x.Id == id);
            if (BorrowedBook != null)
            {
                return BorrowedBook;
            }
            throw new Exception("BorrowedBook not found");
        }

        public void Update(BorrowedBook borrowedBook)
        {
            var borrowed = _context.BorrowedBooks.FirstOrDefault(x => x.Id == borrowedBook.Id);
            if (borrowed != null)
            {
                borrowed.UserId = borrowedBook.UserId;
                borrowed.BookId = borrowedBook.BookId;
                borrowed.DateTime= borrowedBook.DateTime;
            }
            _context.SaveChanges();
        }
        public List<BorrowedDto> GetBorrowed()
        {
            List<BorrowedDto> borrowedList = _context.BorrowedBooks.Select(x => new BorrowedDto
            {
                DateTime =x.DateTime,
                UserId = x.User.Id,
                Username = x.User.FirstName,
                Bookname = x.Book.Name,
            }).ToList();
            return borrowedList;
        }
        public BorrowedBook? GetBorrowedBookUser(int bookid, User user)
        {
            var borrowed=_context.BorrowedBooks.Where(x => x.UserId == user.Id).FirstOrDefault(x => x.BookId == bookid);
            if (borrowed != null)
            {
                return borrowed;
            }
            else
                return null;
        }
        public List<BorrowedDto> GetAllBorrowedBooksUser(int userid)
        {
            var borrowed=_context.BorrowedBooks.Where(x=>x.UserId == userid).Select(x => new BorrowedDto
            {
                DateTime = x.DateTime,
                UserId = x.User.Id,
                Username = x.User.FirstName,
                Bookname = x.Book.Name,
            }).ToList();
            return borrowed;
        }
    }
}

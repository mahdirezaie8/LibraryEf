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
    public class BookRepository : IBookRepository
    {
        AppDbContext _context = new AppDbContext();
        public int Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            throw new Exception("book not found");
        }

        public List<BookDto> GetAll()
        {
            var books = _context.Books.Select(x => new BookDto
            {
                Name = x.Name,
                Author = x.Author,
                YearOfPublication = x.YearOfPublication,
                CategoryName = x.Category.Name,
                Rating = x.reviews.Average(x => x.Rating),
                comment = x.reviews.Where(x => x.Confirmation == true).Select(x => x.Comment).ToList()
            }).ToList();
            return books;
        }

        public Book GetById(int id)
        {
            var book= _context.Books.Include(b => b.Category).FirstOrDefault(x=>x.Id == id);
            if(book != null)
            {
                return book;
            }
            throw new Exception("book not found");
        }

        public void Update(Book book)
        {
            var book1 = _context.Books.FirstOrDefault(x => x.Id == book.Id);
            if (book1 != null)
            {
                book1.Name = book.Name;
                book1.Author = book.Author;
                book1.YearOfPublication = book.YearOfPublication;
                book1.CategoryId = book.CategoryId;
            }
            _context.SaveChanges();
        }
    }
}

using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;
namespace Library3.Servises
{
    public class BookService: IBookService
    {
        IBookRepository bookRepository=new BookRepository();
        ICategoryRepository categoryRepository=new CategoryRepository();
        public void CreateBook(string name,string author,int yearofpoblication,int categoryid)
        {
            var category=categoryRepository.GetById(categoryid);
            var oldbook=bookRepository.GetAll().FirstOrDefault(x => x.Name==name);
            if (oldbook!=null)
            {
                throw new Exception("There is a book whith this name");
            }
            else if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || yearofpoblication == null)
            {
                throw new Exception("error");
            }
            else
            {
                Book book = new Book()
                {
                    Name = name,
                    Author = author,
                    YearOfPublication = yearofpoblication,
                    CategoryId = category.ID,
                };
                bookRepository.Create(book);
                //categoryRepository.AddBookCategory(categoryid, book);
            }
        }
        public List<BookDto> GetAllBooks(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new Exception("category null");
            }
            var oldcategory = bookRepository.GetAll().FirstOrDefault(x => x.CategoryName.ToLower() == category);
            if(oldcategory!=null)
            {
                var books = bookRepository.GetAll().Where(x => x.CategoryName.ToLower() == category).ToList();
                return books;
            }
            else
                throw new Exception("category not found");
        }

    }
}

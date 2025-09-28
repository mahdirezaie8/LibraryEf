using Library3.Dto;
using Library3.ntts;
namespace Library3.Contracts
{
    public interface IBookRepository
    {
        int Create(Book book);
        void Update(Book book);
        List<BookDto> GetAll();
        Book GetById(int id);
        void Delete(int id);
    }
}

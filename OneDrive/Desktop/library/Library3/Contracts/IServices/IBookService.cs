using Library3.Dto;
namespace Library3.Contracts.IServices
{
    public interface IBookService
    {
        public void CreateBook(string name, string author, int yearofpoblication, int categoryid);
        public List<BookDto> GetAllBooks(string category);
    }
}

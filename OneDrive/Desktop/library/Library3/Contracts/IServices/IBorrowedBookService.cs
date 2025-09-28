using Library3.Dto;
using Library3.ntts;
namespace Library3.Contracts.IServices
{
    public interface IBorrowedBookService
    {
        public void CreateBorrowed(int bookid, User user);
        public List<BorrowedDto> GetAllBorrowedBooksUser(User user);
        public void ReturnBook(int borrowedid, int userid);
    }
}

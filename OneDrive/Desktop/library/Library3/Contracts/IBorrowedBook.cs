using Library3.Dto;
using Library3.ntts;
namespace Library3.Contracts
{
    public interface IBorrowedBook
    {
        public int Create(BorrowedBook borrowedBook);
        public void Delete(int id);
        public BorrowedBook GetById(int id);
        public void Update(BorrowedBook borrowedBook);
        public List<BorrowedDto> GetBorrowed();
        public BorrowedBook? GetBorrowedBookUser(int bookid, User user);
        public List<BorrowedDto> GetAllBorrowedBooksUser(int userid);
        public int GetFine(int timeSpan);
    }
}

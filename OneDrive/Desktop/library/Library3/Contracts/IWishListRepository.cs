using Library3.Dto;
using Library3.ntts;

namespace Library3.Contracts
{
    public interface IWishListRepository
    {
        public int Create(Wishlist wishlist);
        public void Update(Wishlist wishlist);
        public List<WishListDto> GetAll();
        public Wishlist GetById(int id);
        public void Delete(int id);
        public Wishlist? GetWishListUser(int userid, int bookid);
        public List<WishListDto> GetAllWishListUser(int userid);
    }
}

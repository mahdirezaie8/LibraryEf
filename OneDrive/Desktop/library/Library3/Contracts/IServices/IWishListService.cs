using Library3.Dto;
using Library3.ntts;
namespace Library3.Contracts.IServices
{
    public interface IWishListService
    {
        public void CreateWishlist(User user, int bookid);
        public void DeleteWishlist(int wishid, int userid);
        public List<WishListDto> ShowAllWishListUser(User user);
        public List<WishListDto> ShowAllWishList();
    }
}

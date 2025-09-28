using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;
namespace Library3.Servises
{
    public class WishListService: IWishListService
    {
        IWishListRepository _wishListRepository =new WishListRepository();
        IBookRepository _bookRepository=new BookRepository();
        public void CreateWishlist(User user,int bookid)
        {
           var book=_bookRepository.GetById(bookid);
            var oldwistlist=_wishListRepository.GetWishListUser(user.Id,book.Id);
            if (oldwistlist == null)
            {
                Wishlist wishlist = new Wishlist()
                {
                    UserId = user.Id,
                    BookId = book.Id,
                    CreateAt = DateTime.Now,
                };
                _wishListRepository.Create(wishlist);
            }
            else
                throw new Exception("this book is in your whishlist");
        }
        public void DeleteWishlist(int wishid,int userid)
        {
            var wish=_wishListRepository.GetById(wishid);
            if (wish != null)
            {
                if (wish.UserId == userid)
                {
                    _wishListRepository.Delete(wishid);
                }
                else
                    throw new Exception("this isnt whishlist id for you");
            }
        }
        public List<WishListDto> ShowAllWishListUser(User user)
        {
            var wishlist = _wishListRepository.GetAllWishListUser(user.Id);
            if (wishlist.Count() > 0)
            {
                return wishlist;
            }
            else
                throw new Exception("wishlist is null");
        }
        public List<WishListDto> ShowAllWishList()
        {
           var wishLists =_wishListRepository.GetAll();
            if (wishLists.Count() > 0)
            {
                return wishLists;
            }
            else
                throw new Exception("wishlist is null");
        }
    }
}

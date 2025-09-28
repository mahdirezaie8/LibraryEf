using Library3.Contracts;
using Library3.Dto;
using Library3.Infrastructure;
using Library3.ntts;
namespace Library3.Repositories
{
    public class WishListRepository: IWishListRepository
    {
        AppDbContext _context = new AppDbContext();
        public int Create(Wishlist wishlist)
        {
            _context.Add(wishlist);
            _context.SaveChanges();
            return wishlist.Id;
        }
       public void Update(Wishlist wishlist)
        {
            var oldWishlist=_context.Wishlists.FirstOrDefault(x=>x.Id == wishlist.Id);
            if (oldWishlist != null)
            {
                oldWishlist.Id = wishlist.Id;
                oldWishlist.UserId = wishlist.UserId;
                oldWishlist.BookId = wishlist.BookId;
                oldWishlist.CreateAt = DateTime.Now;
            }
            _context.SaveChanges();
        }
        public List<WishListDto> GetAll()
        {
            var wishlist=_context.Wishlists.Select(x=>new WishListDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Username=x.User.FirstName,
                BookId=x.BookId,
                Bookname=x.Book.Name,
                CreateAt=x.CreateAt,
            }).ToList();
            return wishlist;
        }
       public Wishlist GetById(int id)
        {
            var Wish= _context.Wishlists.FirstOrDefault(x=>x.Id==id);
            if (Wish!=null)
            {
                return Wish;
            }
            throw new Exception("Wishlist not found");
        }
       public void Delete(int id)
        {
            var Wish = _context.Wishlists.FirstOrDefault(x => x.Id == id);
            if (Wish != null)
            {
                _context.Remove(Wish);
                _context.SaveChanges();
            }
            throw new Exception("Wishlist not found");
        }
        public Wishlist? GetWishListUser(int userid,int bookid)
        {
            var wish = _context.Wishlists.Where(x=>x.UserId==userid).FirstOrDefault(x=>x.BookId==bookid);
            if(wish!=null)
            {
                return wish;
            }
            return null;
        }
        public List<WishListDto> GetAllWishListUser(int userid)
        {
            var wishlist =_context.Wishlists.Where(x=> x.UserId==userid).Select(x=>new WishListDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Username = x.User.FirstName,
                BookId = x.BookId,
                Bookname = x.Book.Name,
                CreateAt = x.CreateAt,
            }).ToList();
            return wishlist;
        }
    }
}

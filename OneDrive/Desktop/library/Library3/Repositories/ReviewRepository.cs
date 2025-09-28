using Library3.Contracts;
using Library3.Dto;
using Library3.Infrastructure;
using Library3.ntts;
namespace Library3.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        AppDbContext _context = new AppDbContext();
        public int Create(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review.ID;
        }

        public void Delete(int id)
        {
            var review = _context.Reviews.FirstOrDefault(re => re.ID == id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
            else
                throw new Exception("review id not found");
        }

        public List<ReviewDto> GetAll()
        {
            var review = _context.Reviews.Select(x => new ReviewDto
            {
                Id = x.ID,
                UserId=x.UserId,
                BookName = x.Book.Name,
                Comment = x.Comment,
                CreatedAt = DateTime.Now,
                Rating = x.Rating,
                Confirmation = x.Confirmation,
            }).ToList();
            return review;
        }

        public Review GetById(int id)
        {
            var review = _context.Reviews.FirstOrDefault(re => re.ID == id);
            if (review != null)
            {
                return review;
            }
            else
                throw new Exception("review id not found");
        }

        public void Update(Review review)
        {
            var oldreview = _context.Reviews.FirstOrDefault(re => re.ID == review.ID);
            if (review != null)
            {
                oldreview.UserId = review.UserId;
                oldreview.BookId = review.BookId;
                oldreview.Comment = review.Comment;
                oldreview.Rating = review.Rating;
                oldreview.CreatedAt = review.CreatedAt;
                oldreview.Confirmation = review.Confirmation;
            }
            _context.SaveChanges();
        }
        public List<ReviewDto> GetUserReview(int userid)
        {
            var review = _context.Reviews.Where(x => x.UserId == userid).Select(x => new ReviewDto
            {
                Id = x.ID,
                UserId= x.UserId,
                BookName = x.Book.Name,
                Comment = x.Comment,
                CreatedAt = DateTime.Now,
                Rating = x.Rating,
                Confirmation = x.Confirmation,
            }).ToList();
            return review;
        }
        public List<ReviewDto> GetReviewsConfirmationIsFalse()
        {
            var review = _context.Reviews.Where(x => x.Confirmation == false).Select(x => new ReviewDto
            {
                Id = x.ID,
                UserId = x.UserId,
                BookName = x.Book.Name,
                Comment = x.Comment,
                CreatedAt = DateTime.Now,
                Rating = x.Rating,
                Confirmation = x.Confirmation,
            }).ToList();
            return review;
        }
    }
}

using Library3.Contracts;
using Library3.Contracts.IServices;
using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;
namespace Library3.Servises
{
    public class ReviewService: IReviewService
    {
        IReviewRepository _reviewRepository=new ReviewRepository();
        IBookRepository _bookRepository=new BookRepository();
        public void CreateReview(int userid,int bookid,int rating,string comment)
        {
            var book=_bookRepository.GetById(bookid);
            if(rating>=0&&rating<=10)
            {
                Review review = new Review()
                {
                    BookId = book.Id,
                    UserId = userid,
                    Rating = rating,
                    Comment = comment,
                    CreatedAt = DateTime.Now,
                };
                _reviewRepository.Create(review);
            }
            else
                throw new Exception("the rating is between 0 and 10");
        }
        public void EditComments(int userid,int reviewid,string newcomment)
        {
            var review = _reviewRepository.GetById(reviewid);
            if(review != null)
            {
                if (review.UserId == userid)
                {
                    review.Comment = newcomment;
                    _reviewRepository.Update(review);
                }
                else
                    throw new Exception("you didnt write this comment");
            }
        }
        public void DeleteComment(int userid,int reviewid)
        {
            var review= _reviewRepository.GetById(reviewid);
            if(review != null)
            {
                if(review.UserId == userid)
                {
                    _reviewRepository.Delete(review.ID);
                }
                else
                    throw new Exception("you didnt delete this comment");
            }
            
        }
        public List<ReviewDto> GetReviewsuser(User user)
        {
            var getriview = _reviewRepository.GetUserReview(user.Id);
            if (getriview.Count()>0)
            {
                return getriview;
            }
            else
                throw new Exception("Review is null");
        }
        public List<ReviewDto> GetReviewsConfirmation()
        {
          var review=_reviewRepository.GetReviewsConfirmationIsFalse();
            if (review.Count()>0)
            {
                return review;
            }
            else
                throw new Exception("Review is null");
        }
        public void EditConfirmation(int reviewid)
        {
            var review = _reviewRepository.GetById(reviewid);
            if (review != null)
            {
                review.Confirmation = true;
                _reviewRepository.Update(review);
            }
        }
    }
}

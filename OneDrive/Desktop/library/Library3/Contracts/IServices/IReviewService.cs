using Library3.Dto;
using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts.IServices
{
    public interface IReviewService
    {
        public void CreateReview(int userid, int bookid, int rating, string comment);
        public void EditComments(int userid, int reviewid, string newcomment);
        public void DeleteComment(int userid, int reviewid);
        public List<ReviewDto> GetReviewsuser(User user);
        public List<ReviewDto> GetReviewsConfirmation();
        public void EditConfirmation(int reviewid);
    }
}

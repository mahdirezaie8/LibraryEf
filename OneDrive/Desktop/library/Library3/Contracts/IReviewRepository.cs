using Library3.Dto;
using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts
{
    public interface IReviewRepository
    {
        int Create(Review review);
        void Update(Review review);
        List<ReviewDto> GetAll();
        Review GetById(int id);
        void Delete(int id);
        public List<ReviewDto> GetUserReview(int userid);
        public List<ReviewDto> GetReviewsConfirmationIsFalse();
    }
}

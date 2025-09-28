using Library3.Enums;
namespace Library3.ntts
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public RoleEnum Role { get; set; }
        public List<BorrowedBook> BorrowedBooks { get; set; } = [];
        public List<Review> reviews { get; set; } = [];
        public List<Wishlist> wishlist { get; set; } = [];
        public int? PenaltyAmount { get; set; }


    }
}

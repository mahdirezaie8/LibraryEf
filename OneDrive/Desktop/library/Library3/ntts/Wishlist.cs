namespace Library3.ntts
{
    public class Wishlist
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public DateTime CreateAt { get; set; }

    }
}

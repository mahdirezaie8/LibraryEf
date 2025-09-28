namespace Library3.ntts
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

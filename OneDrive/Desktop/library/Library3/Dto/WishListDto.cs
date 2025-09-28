namespace Library3.Dto
{
    public class WishListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string Bookname { get; set; }
        public int BookId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

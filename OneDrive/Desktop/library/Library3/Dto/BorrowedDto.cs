namespace Library3.Dto
{
    public class BorrowedDto
    {
        public string Username { get; set; }
        public int BookId { get; set; }
        public string Bookname { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}

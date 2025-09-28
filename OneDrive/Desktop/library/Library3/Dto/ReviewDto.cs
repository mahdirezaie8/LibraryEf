namespace Library3.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Confirmation { get; set; }
    }
}

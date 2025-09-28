namespace Library3.ntts
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = [];
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.ntts
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Review> reviews { get; set; } = [];
    }
}

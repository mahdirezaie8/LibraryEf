using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public string CategoryName { get; set; }
        public List<string> comment { get; set; } = [];
        public double? Rating { get; set; }
    }
}

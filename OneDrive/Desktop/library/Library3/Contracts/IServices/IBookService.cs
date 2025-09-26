using Library3.Dto;
using Library3.ntts;
using Library3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts.IServices
{
    public interface IBookService
    {
        public void CreateBook(string name, string author, int yearofpoblication, int categoryid);
        public List<BookDto> GetAllBooks(string category);
    }
}

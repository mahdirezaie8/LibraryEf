using Library3.Dto;
using Library3.ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Contracts
{
    public interface IBookRepository
    {
        int Create(Book book);
        void Update(Book book);
        List<BookDto> GetAll();
        Book GetById(int id);
        void Delete(int id);
    }
}

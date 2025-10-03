using Quiz2.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Contact.IService
{
    public interface ICardService
    {
        public Card login(string cardnumber, string paswword);
    }
}

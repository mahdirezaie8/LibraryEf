using Quiz2.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Contact.IService
{
    public interface ITrandsactionService
    {
        public void Transfer(string firstcardNumber, string lastcardNumber, float Amount);
        public List<TransactionDto> GetAllTransactionUser(string cardnumber);
    }
}

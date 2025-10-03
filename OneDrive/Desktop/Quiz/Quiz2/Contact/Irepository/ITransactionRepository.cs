using Quiz2.Dto;
using Quiz2.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Contact.Irepository
{
    public interface ITransactionRepository
    {
        public int Creat(Transaction1 transaction);
        public List<TransactionDto> GetAll();
        public Transaction1 Getbyid(int id);
        public List<TransactionDto> GetAllTransactionUser(string cardnumber);
    }
}

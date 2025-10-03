using Quiz2.Contact.Irepository;
using Quiz2.Dto;
using Quiz2.entity;
using Quiz2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Quiz2.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        AppDbContext _context = new AppDbContext();
        public int Creat(Transaction1 transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction.TransactionId;
        }
        public List<TransactionDto> GetAll()
        {
            var transaction=_context.Transactions.Select(x=>new TransactionDto
            {
                TransactionId = x.TransactionId,
                SourceCardNumber=x.FirstCard.CardNumber,
                DestinationCardNumber=x.LastCard.CardNumber,
                Amount=x.Amount,
                TransactionDate=x.TransactionDate,
                IsSuccessful=x.IsSuccessful,
            }).ToList();
            return transaction;
        }
        public Transaction1 Getbyid(int id)
        {
            var tran= _context.Transactions.FirstOrDefault(x=>x.TransactionId==id);
            if (tran != null)
            {
                return tran;
            }
            else
                throw new Exception("id not found");
        }
        public List<TransactionDto> GetAllTransactionUser(string cardnumber)
        {
            var transaction = _context.Transactions.Where(x=>x.SourceCardNumber==cardnumber||x.DestinationCardNumber==cardnumber).Select(x => new TransactionDto
            {
                TransactionId = x.TransactionId,
                SourceCardNumber = x.FirstCard.CardNumber,
                DestinationCardNumber = x.LastCard.CardNumber,
                Amount = x.Amount,
                TransactionDate = x.TransactionDate,
                IsSuccessful = x.IsSuccessful,
            }).ToList();
            return transaction;
        }
    }
}

using Quiz2.Contact.Irepository;
using Quiz2.Contact.IService;
using Quiz2.Dto;
using Quiz2.entity;
using Quiz2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Services
{
    public class TrandsactionService: ITrandsactionService
    {
        ITransactionRepository TransactionRepository=new TransactionRepository();
        ICardRepository cardRepository = new CardRepository();
        public void Transfer(string firstcardNumber, string lastcardNumber, float Amount)
        {
            var firstc=cardRepository.GetCard(firstcardNumber);
            var lastc=cardRepository.GetCard(lastcardNumber);
            if (firstc.Balance > Amount)
            {
                if (Amount > 0)
                {
                    Transaction1 transaction1 = new Transaction1()
                    {
                        Amount = Amount,
                        SourceCardNumber = firstc.CardNumber,
                        DestinationCardNumber = lastc.CardNumber,
                        TransactionDate = DateTime.Now,
                        FirstCardId = firstc.Id,
                        LastCardId = lastc.Id,
                        IsSuccessful = true,
                    };
                    TransactionRepository.Creat(transaction1);
                    firstc.Balance = firstc.Balance - Amount;
                    lastc.Balance = lastc.Balance + Amount;
                    cardRepository.UpdateCard(firstc);
                    cardRepository.UpdateCard(lastc);
                }
                else
                    throw new Exception("amount is greater than 0");
            }
            else
                throw new Exception("Insufficient inventory");
        }
        public List<TransactionDto> GetAllTransactionUser(string cardnumber)
        {
            var Transaction=TransactionRepository.GetAllTransactionUser(cardnumber);
            if(Transaction.Count()>0)
            {
                return Transaction;
            }
            else
                throw new Exception("list Transaction is null");
        }
    }
}

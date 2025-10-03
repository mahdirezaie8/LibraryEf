using Quiz2.Contact.Irepository;
using Quiz2.entity;
using Quiz2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Repositories
{
    public class CardRepository: ICardRepository
    {
        AppDbContext _context = new AppDbContext();
        public int Creat(Card card)
        {
            _context.Cards.Add(card);
           _context.SaveChanges();
            return card.Id;
        }
        public List<Card> GetCards()
        {
            var cards = _context.Cards.ToList();
            return cards;
        }
        public Card GetCard(string Cardnumber)
        {
            var card=_context.Cards.FirstOrDefault(x =>x.CardNumber==Cardnumber);
            if (card != null)
            {
                return card;
            }
            else
                throw new Exception("card not found");
        }
        public void UpdateCard(Card card)
        {
            var oldcard=_context.Cards.FirstOrDefault(x=>x.Id==card.Id);
            if (oldcard != null)
            {
               oldcard.Balance= card.Balance;
                oldcard.FaildedAttempts= card.FaildedAttempts;
            }
            _context.SaveChanges();
        }

    }
}

using Quiz2.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Contact.Irepository
{
    public interface ICardRepository
    {
        public int Creat(Card card);
        public List<Card> GetCards();
        public Card GetCard(string Cardnumber);
        public void UpdateCard(Card card);
    }
}

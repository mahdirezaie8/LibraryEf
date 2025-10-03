using Quiz2.Contact.Irepository;
using Quiz2.Contact.IService;
using Quiz2.entity;
using Quiz2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Services
{
    public class CardService: ICardService
    {
        ICardRepository cardRepository=new CardRepository();
        public Card login(string cardnumber,string paswword)
        {
            var card=cardRepository.GetCard(cardnumber);
            if (card.FaildedAttempts < 3)
            {
                if (card != null && cardnumber.Length == 16)
                {
                    if (paswword == card.Password)
                    {
                        return card;
                    }
                    else
                    {
                        card.FaildedAttempts = card.FaildedAttempts + 1;
                        if (card.FaildedAttempts == 3)
                        {
                            card.IsActive = false;
                        }
                        cardRepository.UpdateCard(card);
                        throw new Exception("password is false");
                    }
                }
                else
                    throw new Exception("cardnumber==16 or cardnumber not found");
            }
            else
                throw new Exception("invalid card");
        }
        
    }
}

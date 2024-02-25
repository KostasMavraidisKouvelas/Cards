using CardsWeb.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cards.Models;

namespace Cards.Application
{
    public class CardService : BaseService
    {
        public CardService(CardsDbContext context) : base(context)
        {

        }

        public async Task<Card> AddCard(Card card)
        {
            _context.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateCard(Card card)
        {
            var itemTocheck = _context.Cards.FirstOrDefault(c => c.Id == card.Id);

            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return card;
        }


        public async Task DeleteCard(Guid cardId)
        {

            var item = _context.Cards.FirstOrDefault(x => x.Id == cardId);
            if (item != null)
                _context.Entry(item).State = EntityState.Deleted;
            else
                throw new Exception("The item you tried to delete does not appear to exist");

            await _context.SaveChangesAsync();

        }
    }
}

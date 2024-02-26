using CardsWeb.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cards.Application.Filters;
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
            var itemToCheck = await _context.Cards.FindAsync(card.Id);

            if (itemToCheck != null)
            {
                _context.Entry(itemToCheck).CurrentValues.SetValues(card);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("The card you tried to update does not exist");
            }

            return card;
        }


        public async Task DeleteCard(Guid cardId)
        {
            var item = _context.Cards.FirstOrDefault(x => x.Id == cardId);

            if (item != null)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            else
            {
                throw new ArgumentException("The card you tried to delete does not exist", nameof(cardId));
            }

            await _context.SaveChangesAsync();
        }

        public IQueryable<Card> GetByUserId(Guid userId,CardFilter options)
        {
            return _context.Set<Card>()
                    .FilterCardBy(options.CardFilterBy,options.FilterValue)
                    .OrderCardsBy(options.OrderByOptions)
                    .Paginate<Card>(options.PageSize,options.PageNum);
        }
    }
}

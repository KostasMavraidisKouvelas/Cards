using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Models;

namespace Cards.Application.Filters
{
    public enum CardFilterBy
    {
        [Display(Name = "All")] NoFilter = 0,
        [Display(Name = "By Name...")] ByName,
        [Display(Name = "By Status...")] ByColor
    }

    public enum OrderByOptions
    {
        [Display(Name = "sort by...")] SimpleOrder = 0,
        [Display(Name = "Date Created ↑")] DateCreatedAsc,
        [Display(Name = "Date Created ↓")] DateCreatedDesc,
    }

    public class CardFilter : SortFilteringPaginations
    {
        public CardFilterBy CardFilterBy { get; set; }
        public OrderByOptions OrderByOptions { get; set; }
        public string FilterValue { get; set; }

    }

    public static class CardListSort
    {
        public static IQueryable<Card> OrderCardsBy
        (this IQueryable<Card> cards,
            OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder: //#A
                    return cards; //#A
                case OrderByOptions.DateCreatedAsc: //#B
                    return cards.OrderBy(x => //#B
                        x.CreatedAt); //#B
                case OrderByOptions.DateCreatedDesc: //#C
                    return cards.OrderByDescending( //#C
                        x => x.CreatedAt); //#C
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }
        public static IQueryable<Card> FilterCardBy(
            this IQueryable<Card> cards,
            CardFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue)) 
                return cards; 

            switch (filterBy)
            {
                case CardFilterBy.NoFilter:                       
                    return cards;                                  
                case CardFilterBy.ByColor: //
                    return cards.Where(x =>                        
                        x.Color == filterValue);       
                case CardFilterBy.ByName:
                    return cards.Where(x => filterValue.Contains(x.Name));
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }

    }
}

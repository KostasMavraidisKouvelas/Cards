using CardsWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application
{
    public class CardService: BaseService
    {
        public CardService(CardsDbContext context) : base(context)
        {

        }
    }
}

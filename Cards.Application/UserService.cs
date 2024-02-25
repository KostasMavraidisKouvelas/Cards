using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsWeb.DataAccess;

namespace Cards.Application
{
    public class UserService: BaseService
    {
        public UserService(CardsDbContext context) : base(context)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsWeb.DataAccess;

namespace Cards.Application
{
    public class BaseService
    {
        protected readonly CardsDbContext _context;

        public BaseService()
        { }
        public BaseService(CardsDbContext dbContext)
        {
            _context = dbContext;
        }

        public IQueryable GetList<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}

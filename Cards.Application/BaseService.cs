using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.DataAccess;
using CardsWeb.Models.Base;
using Microsoft.EntityFrameworkCore;

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

        public T GetById<T>(Guid Id) where T : BaseModel
        {
            return _context.Set<T>().FirstOrDefault(c=>c.Id==Id);
        }
        public IQueryable<T> GetList<T>() where T : class
        {
            return  _context.Set<T>();
        }
    }
}

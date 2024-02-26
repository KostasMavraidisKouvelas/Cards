using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Filters
{
    public static class GenericPages
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int pageSize, int pagenum) where T : class
        {
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize) ,"pagesize cannot be less than one");

            if(pagenum!=0)
                queryable = queryable.Skip((pagenum - 1) * pageSize);

            return queryable.Take(pageSize);
        }
    }
}

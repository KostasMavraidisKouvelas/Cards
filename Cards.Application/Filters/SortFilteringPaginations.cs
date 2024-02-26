using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Filters
{
    public class SortFilteringPaginations
    {
        private int _pageNum = 1;
        private int _pageSize = 10;
        private int _limit = 0;
        private int _offset = 0;

        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        public int Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
    }
}

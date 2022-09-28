using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> Source ,int Page,int PageSize , out int RowsCount)
        {
            RowsCount = Source.Count();
            return Source.Skip((Page - 1) * PageSize).Take(PageSize);
        }
    }
}

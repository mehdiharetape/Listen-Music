using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, 
            int PageSize, out int rowCount)
        {
            rowCount = source.Count();
            return source.Skip((page - 1) * PageSize).Take(PageSize);
        }
    }
}

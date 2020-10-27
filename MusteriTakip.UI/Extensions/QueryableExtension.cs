using AutoMapper;
using MusteriTakip.UI.ClassMaping;
using MusteriTakip.UI.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Extensions
{

    public static class QueryableExtension
    {

        public static PagedList<TOutput> PagedList<TOutput, TInput>(this IQueryable<TInput> data, Func<IEnumerable<TInput>, IEnumerable<TOutput>> map, int currentPage = 1, int pageSize = 10)
            where TInput : class
            where TOutput : class
        {

            if (currentPage == 0)
                currentPage = 1;

            var returnData = data.AsQueryable().Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<TOutput>
            {
                Data = map(returnData),
                CurrentPage = currentPage,
                PageCount = (int)Math.Ceiling(((double)data.Count() / (double)pageSize)),
                PageSize = pageSize
            };

        }
    }
}

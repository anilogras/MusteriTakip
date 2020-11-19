using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.PagedList
{
    public class PagedList<T> : PagedItemModel
    {
        public IEnumerable<T> Data { get; set; }
    }
}

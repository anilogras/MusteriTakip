using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.DataAccess.Interfaces
{
    public interface IFisDal : IGenericDal<Fis>
    {
        IQueryable<Fis> CariFisleri(int id);
        IQueryable<Fis> KullaniciFisleri(int id);
        Task<Fis> FisGetirFullData(int id);
    }
}

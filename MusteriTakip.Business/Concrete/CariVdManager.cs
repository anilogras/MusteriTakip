using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;

namespace MusteriTakip.Business.Concrete
{
    public class CariVdManager:GenericManager<CariVd> , ICariVdService
    {

        public CariVdManager(ICariVdDal cariVdDal):base(cariVdDal)
        {
        }
    }
}

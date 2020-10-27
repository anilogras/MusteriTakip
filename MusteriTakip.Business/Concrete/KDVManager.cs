using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;

namespace MusteriTakip.Business.Concrete
{
    public class KDVManager : GenericManager<KDV> , IKDVService
    {

        public KDVManager(IKDVDal kDVDal) : base(kDVDal)
        {
        }
    }
}

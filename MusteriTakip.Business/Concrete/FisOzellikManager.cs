using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;

namespace MusteriTakip.Business.Concrete
{
    public class FisOzellikManager : GenericManager<FisOzellik> , IFisOzellikService
    {
        public FisOzellikManager(IFisOzellikDal fisOzellikDal):base(fisOzellikDal)
        {
        }
    }
}

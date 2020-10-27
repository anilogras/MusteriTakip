using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class IlceManager : GenericManager<Ilce> , IIlceService
    {
        private readonly IIlceDal _ilceDal;

        public IlceManager(IIlceDal ilceDal):base(ilceDal)
        {
            _ilceDal = ilceDal;
        }

        public List<Ilce> GetByIlceWithIlId(int Id)
        {
            return _ilceDal.GetQueryable(x => x.Sehir == Id).ToList();
        }
    }
}

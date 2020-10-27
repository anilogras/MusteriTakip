using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class CariFaxManager : GenericManager<CariFax> , ICariFaxService
    {
        public CariFaxManager(ICariFaxDal cariFaxDal):base(cariFaxDal)
        {

        }
    }
}

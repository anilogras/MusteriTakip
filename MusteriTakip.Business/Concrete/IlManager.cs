using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class IlManager : GenericManager<Il> , IIlService
    {
        public IlManager(IIlDal ilDal) : base(ilDal)
        {
        }
    }
}

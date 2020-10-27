using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class CariCepManager : GenericManager<CariCep> , ICariCepService
    {
        public CariCepManager(ICariCepDal cariCepDal):base(cariCepDal)
        {

        }
    }
}

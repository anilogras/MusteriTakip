using MusteriTakip.Business.Concrete;
using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class CariAdresManager:GenericManager<CariAdres>, ICariAdresService
    {
        public CariAdresManager(ICariAdresDal cariAdresDal):base(cariAdresDal)
        {
           
        }

    }
}

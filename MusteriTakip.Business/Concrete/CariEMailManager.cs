using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class CariEMailManager : GenericManager<CariEMail>,ICariEMailService
    {
        public CariEMailManager(ICariEMailDal cariEMailDal):base(cariEMailDal)
        {

        }
    }
}

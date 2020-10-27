using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CariWebSiteRepository : GenericRepository<CariWebSite> , ICariWebSiteDal
    {
        public CariWebSiteRepository(MusteriTakipContext context):base(context)
        {

        }
    }
}

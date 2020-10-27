using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class KDVRepository : GenericRepository<KDV> , IKDVDal
    {
        public KDVRepository(MusteriTakipContext context):base(context)
        {

        }
    }
}

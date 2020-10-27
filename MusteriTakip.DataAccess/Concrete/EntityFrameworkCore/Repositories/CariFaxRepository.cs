using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CariFaxRepository:GenericRepository<CariFax>, ICariFaxDal
    {
        public CariFaxRepository(MusteriTakipContext context):base(context)
        {

        }
    }
}

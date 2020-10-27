using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Services
{
    public interface  IIlceService : IGenericService<Ilce>
    {
        List<Ilce> GetByIlceWithIlId(int Id);
    }
}

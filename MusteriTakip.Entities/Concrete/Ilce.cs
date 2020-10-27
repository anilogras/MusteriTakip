using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Entities.Concrete
{
    public class Ilce : ITable
    {
        public int Id { get; set; }
        public int Sehir { get; set; }
        public string IlceAdi { get; set; }

        public virtual List<CariAdres> Adres { get; set; }
    }
}

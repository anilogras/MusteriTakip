using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Entities.Concrete
{
    public class Il : ITable
    {
        public int Id { get; set; }
        public string Sehir { get; set; }

        public virtual List<CariAdres> Adres { get; set; }
    }
}

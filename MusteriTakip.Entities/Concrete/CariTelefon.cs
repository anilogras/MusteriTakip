using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Entities.Concrete
{
   public  class CariTelefon : ITable
    {
        public int Id { get; set; }
        public int CariId { get; set; }

        public string Telefon { get; set; }

        public Cari Cari { get; set; }
    }
}

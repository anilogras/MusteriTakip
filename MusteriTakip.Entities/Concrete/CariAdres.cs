using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusteriTakip.Entities.Concrete
{
    public class CariAdres:ITable
    {
        public int Id { get; set; }
        public int CariId { get; set; }
        public string Adres { get; set; }

        public int IlId { get; set; }
        public int IlceId { get; set; }

        public virtual Il Il { get; set; }
        public virtual Ilce Ilce { get; set; }

        public virtual Cari Cari { get; set; }
    }
}

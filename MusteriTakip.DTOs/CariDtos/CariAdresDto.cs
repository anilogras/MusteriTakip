using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.CariDtos
{
    public class CariAdresDto
    {
        public int Id { get; set; }
        public string Adres { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public virtual Il Il { get; set; }
        public virtual Ilce Ilce { get; set; }
    }
}

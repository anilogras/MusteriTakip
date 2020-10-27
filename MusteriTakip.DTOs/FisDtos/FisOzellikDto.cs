using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.FisDtos
{
    public class FisOzellikDto
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public int? Adet { get; set; }
        public string Aciklama { get; set; }
        public string Olcu { get; set; }
        public double Fiyat { get;set;}
        public int? KDV { get; set; }
        public int Durum { get; set; }
    }
}

using MusteriTakip.DTOs.CariDtos;
using MusteriTakip.DTOs.KullaniciDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.FisDtos
{
    public class FisDto
    {
        public FisDto()
        {
            FisOzellikleri = new List<FisOzellikDto>();
        }

        public int Id { get; set; }
        public double OnOdeme { get; set; }
        public string FisNot { get; set; }
        public bool Faturalandir { get; set; }
        public string FisKullanicisi { get; set; }
        public bool Silindimi { get; set; }
        public DateTime KayitTarihi { get; set; }


        public virtual List<FisOzellikDto> FisOzellikleri { get; set; }

        public virtual KullaniciListDto Kullanici { get; set; }
        public virtual CariListDto Cari { get; set; }
    }
}

using MusteriTakip.DTOs.FisDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.CariDtos
{
    public class CariListDto
    {

        public CariListDto()
        {
            Fislers = new List<FisDto>();
            CariAdresBilgileri = new List<CariAdresDto>();
            CariCepTelefonlari = new List<CariCepDto>();
            CariEMailAdresleri = new List<CariEmailDto>();
            CariFaxTelefonlari = new List<CariFaxDto>();
            CariSabitTelefonlari = new List<CariSabitTelefonDto>();
            CariWebSiteBilgileri = new List<CariWebSiteDto>();
        }

        public int Id { get; set; }
        public string IsletmeAdi { get; set; }
        public string IsletmeYetkilisi { get; set; }
        public bool Aktif { get; set; }

        public string Aciklama { get; set; }

        public virtual List<FisDto> Fislers { get; set; }
        public virtual List<CariAdresDto> CariAdresBilgileri { get; set; }
        public virtual CariVdDto CariVDBilgileri { get; set; }
        public virtual List<CariCepDto> CariCepTelefonlari { get; set; }
        public virtual List<CariEmailDto> CariEMailAdresleri { get; set; }
        public virtual List<CariFaxDto> CariFaxTelefonlari { get; set; }
        public virtual List<CariSabitTelefonDto> CariSabitTelefonlari { get; set; }
        public virtual List<CariWebSiteDto> CariWebSiteBilgileri { get; set; }
    }
}

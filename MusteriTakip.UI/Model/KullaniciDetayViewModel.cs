using MusteriTakip.DTOs.FisDtos;
using MusteriTakip.DTOs.KullaniciDtos;
using MusteriTakip.UI.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Model
{
    public class KullaniciDetayViewModel
    {
        public PagedList<FisDto> Fisler { get; set; }
        public KullaniciListDto Kullanici { get; set; }
    }
}

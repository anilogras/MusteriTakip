using MusteriTakip.DTOs.CariDtos;
using MusteriTakip.DTOs.FisDtos;
using MusteriTakip.UI.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Model
{
    public class CariDetayView
    {
        public CariListDto CariBilgileri { get; set; }
        public PagedList<FisDto> CariFisleri { get; set; }
    }
}

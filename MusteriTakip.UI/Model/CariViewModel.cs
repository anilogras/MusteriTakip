using MusteriTakip.DTOs.CariDtos;
using MusteriTakip.Entities.Concrete;
using MusteriTakip.UI.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Model
{
    public class CariViewModel
    {
       public PagedList<CariListDto> CariBilgileri { get; set; }
    }
}

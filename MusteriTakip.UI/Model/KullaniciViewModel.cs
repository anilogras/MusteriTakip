using MusteriTakip.DTOs.KullaniciDtos;
using MusteriTakip.UI.PagedList;

namespace MusteriTakip.UI.Model
{
    public class KullaniciViewModel
    {
        public PagedList<KullaniciListDto> Kullanicilar { get; set; }
    }
}

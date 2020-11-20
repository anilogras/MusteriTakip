using MusteriTakip.Business.ReturnTypes;
using MusteriTakip.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Services
{
    public interface ICariService : IGenericService<Cari>
    {
        Task<bool> CariEkle(Cari cari);
        IQueryable<Cari> GetCarisForList();
        IQueryable<Cari> GetCarisAllData();
        Task<CariResult> CariGuncelle(Cari cari);
    }
}

using MusteriTakip.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Services
{
    public interface IFisService : IGenericService<Fis>
    {
        IQueryable<Fis> CariFisleri(int id);
        Task<bool> CariFisEkleAsync(Fis fis, User user, int cariId);

        IQueryable<Fis> KullaniciFisleri(int id);

        Task<Fis> FisGetir(int id);

        Task<Fis> FisGetirFullData(int id);
        Task<bool> FisDuzenle(Fis fis);
    }
}

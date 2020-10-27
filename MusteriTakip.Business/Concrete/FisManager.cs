using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Concrete
{
    public class FisManager : GenericManager<Fis>, IFisService
    {
        private readonly IFisDal _fisDal;
        private readonly IFisOzellikService _fisOzellikService;

        public FisManager(IFisDal fisDal, IFisOzellikService fisOzellikService) : base(fisDal)
        {
            _fisDal = fisDal;
            _fisOzellikService = fisOzellikService;
        }

        public IQueryable<Fis> CariFisleri(int id)
        {
            return _fisDal.CariFisleri(id);
        }

        public async Task<bool> CariFisEkleAsync(Fis fis, User user, int cariId)
        {

            fis.KayitTarihi = DateTime.Now;
            fis.UserId = user.Id;
            fis.CariId = cariId;
            fis.FisKullanicisi = user.AdSoyad;
            _fisDal.Add(fis);
            foreach (var fisOzellik in fis.FisOzelliks)
            {
                fisOzellik.FisId = fis.Id;
                _fisOzellikService.Add(fisOzellik);
            }
            return await _fisDal.SaveChangesAsync() != 0;
        }

        public IQueryable<Fis> KullaniciFisleri(int id)
        {
            return _fisDal.KullaniciFisleri(id);
        }

        public async Task<Fis> FisGetir(int id)
        {
            return await _fisDal.GetByIdAsync(id);
        }

        public async Task<Fis> FisGetirFullData(int id)
        {
            return await _fisDal.FisGetirFullData(id);
        }

        public async Task<bool> FisDuzenle(Fis fis)
        {
            Fis duzenlenecekFis = await _fisDal.FisGetirFullData(fis.Id);
            if (duzenlenecekFis != null)
            {
                duzenlenecekFis.FisNot = fis.FisNot;
                duzenlenecekFis.OnOdeme = fis.OnOdeme;

                List<FisOzellik> eklenecekFisOzellikleri = fis.FisOzelliks.Where(x => x.Id == 0).ToList();
                foreach (var fisOzellik in eklenecekFisOzellikleri)
                {
                    fisOzellik.FisId = duzenlenecekFis.Id;
                    _fisOzellikService.Add(fisOzellik);
                }

                foreach (var fisOzellik in duzenlenecekFis.FisOzelliks)
                {
                    if (fis.FisOzelliks.Where(x => x.Id == fisOzellik.Id).Count() == 0)
                    {
                        _fisOzellikService.Delete(duzenlenecekFis.FisOzelliks.FirstOrDefault(x => x.Id == fisOzellik.Id));
                    }
                }

                foreach (var fisOzellik in fis.FisOzelliks.Where(x => x.Id != 0))
                {
                    FisOzellik gFisOzellik = await _fisOzellikService.GetByIdAsync(fisOzellik.Id);
                    gFisOzellik.Aciklama = fisOzellik.Aciklama;
                    gFisOzellik.Adet = fisOzellik.Adet;
                    gFisOzellik.Durum = fisOzellik.Durum;
                    gFisOzellik.Fiyat = fisOzellik.Fiyat;
                    gFisOzellik.KDV = fisOzellik.KDV;
                    gFisOzellik.Olcu = fisOzellik.Olcu;
                    gFisOzellik.Tanim = fisOzellik.Tanim;
                }
                return await _fisDal.SaveChangesAsync() != 0;
            }
            return false;
        }

    }
}

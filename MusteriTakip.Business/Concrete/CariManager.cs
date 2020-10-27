using Microsoft.AspNetCore.Mvc.Razor;
using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Concrete
{
    public class CariManager : GenericManager<Cari>, ICariService
    {

        private readonly ICariDal _cariDal;
        private readonly ICariCepService _cariCepService;
        private readonly ICariEMailService _cariEmailService;
        private readonly ICariFaxService _cariFaxService;
        private readonly ICariTelefonService _cariTelefonService;
        private readonly ICariWebSiteService _cariWebSiteService;
        private readonly ICariAdresService _cariAdresService;
        private readonly ICariVdService _cariVdService;


        public CariManager(ICariDal cariDal, ICariCepService cariCepService, ICariEMailService cariEmailService, ICariFaxService cariFaxService, ICariTelefonService cariTelefonService, ICariWebSiteService cariWebSiteService, ICariAdresService cariAdresService, ICariVdService cariVdService) : base(cariDal)
        {
            _cariDal = cariDal;
            _cariCepService = cariCepService;
            _cariEmailService = cariEmailService;
            _cariFaxService = cariFaxService;
            _cariTelefonService = cariTelefonService;
            _cariWebSiteService = cariWebSiteService;
            _cariAdresService = cariAdresService;
            _cariVdService = cariVdService;
        }

        public async Task<bool> CariEkle(Cari cari)
        {

            _cariDal.Add(cari);
            foreach (var cepTelefonu in cari.CariCeps)
            {
                cepTelefonu.Cari = cari;
                _cariCepService.Add(cepTelefonu);
            }

            foreach (var email  in cari.CariEMails)
            {
                email.Cari = cari;
                _cariEmailService.Add(email);
            }

            foreach (var fax in cari.CariFaxes)
            {
                fax.Cari = cari;
                _cariFaxService.Add(fax);
            }

            foreach (var telefon in cari.CariTelefons)
            {
                telefon.Cari = cari;
                _cariTelefonService.Add(telefon);
            }

            foreach (var web in cari.CariWebSites)
            {
                web.Cari = cari;
                _cariWebSiteService.Add(web);
            }

            foreach (var adres in cari.CariAdreslers)
            {
                adres.Cari = cari;
                _cariAdresService.Add(adres);
            }

            if (cari.CariVd != null)
            {
                cari.CariVd.Cari = cari;
                _cariVdService.Add(cari.CariVd);
            }

            return await _cariDal.SaveChangesAsync() != 0;
        }

        public IQueryable<Cari> GetCarisAllData()
        {
            return _cariDal.GetCarisAllData();
        }

        public IQueryable<Cari> GetCarisForList()
        {
            return _cariDal.GetCarisForList();
        }

       
    }
}

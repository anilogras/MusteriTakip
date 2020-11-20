using Microsoft.AspNetCore.Mvc.Razor;
using MusteriTakip.Business.ReturnTypes;
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

            foreach (var email in cari.CariEMails)
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

        public async Task<CariResult> CariGuncelle(Cari cari)
        {
            CariResult info = new CariResult();
            var guncellenecekCari = _cariDal.GetCarisAllData().FirstOrDefault(x => x.Id == cari.Id);
            guncellenecekCari.Aciklama = cari.Aciklama;
            guncellenecekCari.Aktif = cari.Aktif;
            guncellenecekCari.IsletmeAdi = cari.IsletmeAdi;
            guncellenecekCari.IsletmeYetkilisi = cari.IsletmeYetkilisi;

            if (guncellenecekCari == null)
            {
                info.Success = false;
                info.Errors.Add("Cari Bulunamadı.");
                return info;
            }

            List<CariAdres> cariAdres = new List<CariAdres>();
            cariAdres.AddRange(guncellenecekCari.CariAdreslers);
            foreach (var adres in cari.CariAdreslers)
            {
                if (adres.Id != 0)
                {
                    _cariAdresService.Update(adres);
                    cariAdres.Remove(cariAdres.FirstOrDefault(x => x.Id == adres.Id));
                }
                else
                {
                    adres.Cari = guncellenecekCari;
                    _cariAdresService.Add(adres);
                }
            }


            foreach (var silinecekAdres in cariAdres)
            {
                _cariAdresService.Delete(silinecekAdres);
            }


            List<CariCep> cariCep = new List<CariCep>();
            cariCep.AddRange(guncellenecekCari.CariCeps);
            foreach (var cep in cari.CariCeps)
            {
                if (cep.Id != 0)
                {
                    _cariCepService.Update(cep);
                    cariCep.Remove(cariCep.FirstOrDefault(x => x.Id == cep.Id));
                }
                else
                {
                    cep.Cari = guncellenecekCari;
                    _cariCepService.Add(cep);
                }

            }

            foreach (var silinecekCep in cariCep)
            {
                _cariCepService.Delete(silinecekCep);
            }




            List<CariEMail> cariEmail = new List<CariEMail>();
            cariEmail.AddRange(guncellenecekCari.CariEMails);
            foreach (var email in cari.CariEMails)
            {
                if (email.Id != 0)
                {
                    _cariEmailService.Update(email);
                    cariEmail.Remove(cariEmail.FirstOrDefault(x => x.Id == email.Id));
                }
                else
                {
                    email.Cari = guncellenecekCari;
                    _cariEmailService.Add(email);
                }

            }

            foreach (var silinecekEmail in cariEmail)
            {
                _cariEmailService.Delete(silinecekEmail);
            }


            List<CariFax> cariFax = new List<CariFax>();
            cariFax.AddRange(guncellenecekCari.CariFaxes);
            foreach (var fax in cari.CariFaxes)
            {
                if (fax.Id != 0)
                {
                    _cariFaxService.Update(fax);
                    cariFax.Remove(cariFax.FirstOrDefault(x => x.Id == fax.Id));
                }
                else
                {
                    fax.Cari = guncellenecekCari;
                    _cariFaxService.Add(fax);
                }

            }
            foreach (var silinecekFax in cariFax)
            {
                _cariFaxService.Delete(silinecekFax);
            }



            List<CariTelefon> cariTelefon = new List<CariTelefon>();
            cariTelefon.AddRange(guncellenecekCari.CariTelefons);
            foreach (var tel in cari.CariTelefons)
            {
                if (tel.Id != 0)
                {
                    _cariTelefonService.Update(tel);
                    cariTelefon.Remove(cariTelefon.FirstOrDefault(x => x.Id == tel.Id));
                }
                else
                {
                    tel.Cari = guncellenecekCari;
                    _cariTelefonService.Add(tel);
                }

            }
            foreach (var silinecekTel in cariTelefon)
            {
                _cariTelefonService.Delete(silinecekTel);
            }



            List<CariWebSite> cariWebSite = new List<CariWebSite>();
            cariWebSite.AddRange(guncellenecekCari.CariWebSites);
            foreach (var web in cari.CariWebSites)
            {
                if (web.Id != 0)
                {
                    _cariWebSiteService.Update(web);
                    cariWebSite.Remove(cariWebSite.FirstOrDefault(x => x.Id == web.Id));
                }
                else
                {
                    web.Cari = guncellenecekCari;
                    _cariWebSiteService.Add(web);
                }

            }
            foreach (var silinecekWeb in cariWebSite)
            {
                _cariWebSiteService.Delete(silinecekWeb);
            }

            if(cari.CariVd != null)
            {
                _cariVdService.Update(cari.CariVd);
            }

            _cariDal.Update(guncellenecekCari);
            var result = await _cariDal.SaveChangesAsync()  != 0;

            info.Success = result;

            return info;
        }


    }
}

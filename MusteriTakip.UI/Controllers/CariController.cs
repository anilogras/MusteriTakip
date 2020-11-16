using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusteriTakip.Business.Services;
using MusteriTakip.DTOs.CariDtos;
using MusteriTakip.DTOs.FisDtos;
using MusteriTakip.Entities.Concrete;
using MusteriTakip.UI.Extensions;
using MusteriTakip.UI.Model;
using Newtonsoft.Json;

namespace MusteriTakip.UI.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class CariController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICariService _cariService;
        private readonly IFisService _fisService;

        public CariController(ICariService cariService, IMapper mapper, IFisService fisService)
        {
            _cariService = cariService;
            _mapper = mapper;
            _fisService = fisService;
        }

        public IActionResult Cariler(int? page)
        {
            CariViewModel model = new CariViewModel()
            {
                CariBilgileri = _cariService.GetQueryable().PagedList(_mapper.Map<IEnumerable<Cari>, IEnumerable<CariListDto>>, page ?? 1, 10)
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("CariListPartial", model.CariBilgileri);
            }

            return View(model);
        }

        public async Task<IActionResult> CariEkle(CariListDto ajaxData)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().Distinct();
                return BadRequest(JsonConvert.SerializeObject(errors));
            }

            if (Request.IsAjaxRequest())
            {
                await _cariService.CariEkle(_mapper.Map<Cari>(ajaxData));
                var data = _cariService.GetQueryable().PagedList(_mapper.Map<IEnumerable<Cari>, IEnumerable<CariListDto>>);
                return PartialView("CariListPartial", data);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult FisSayisiGetir(int id)
        {
            FisSayilari fisSayilari = new FisSayilari
            {
                FaturasizFisler = _fisService.CariFisleri(id).Where(x => x.Faturalandir == false).Count(),
                AcikFisler = _fisService.CariFisleri(id).Where(x => x.FisOzelliks.Any(xc => xc.Durum <= 2)).Count(),
                ToplamFis = _fisService.CariFisleri(id).Count()
            };
            return Json(JsonConvert.SerializeObject(fisSayilari));
        }

        public async Task<IActionResult> CariDetay(int id, int? page)
        {
            CariDetayView model = new CariDetayView
            {
                CariBilgileri = _mapper.Map<CariListDto>(await _cariService.GetByIdAsync(id)),
                CariFisleri = _fisService.CariFisleri(id).PagedList(_mapper.Map<IEnumerable<Fis>, IEnumerable<FisDto>>, page ?? 1, 10)
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/View/Fis/FisListPartial/", model.CariFisleri);
            }

            return View(model);
        }

        public async Task<IActionResult> CariSil(int id)
        {

            if (Request.IsAjaxRequest())
            {
                 _cariService.Delete(new Cari { Id = id });
                await _cariService.SaveChangeAsync();
                return PartialView("CariListPartial", _cariService.GetQueryable().PagedList(_mapper.Map<IEnumerable<Cari>, IEnumerable<CariListDto>>, 1, 10));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusteriTakip.Business.Services;
using MusteriTakip.DTOs.FisDtos;
using MusteriTakip.Entities.Concrete;
using MusteriTakip.UI.Extensions;
using MusteriTakip.UI.Model;
using Newtonsoft.Json;

namespace MusteriTakip.UI.Controllers
{
    public class FisController : Controller
    {

        private readonly IFisService _fisService;
        private readonly IMapper _mapper;

        public FisController(IFisService fisService, IMapper mapper)
        {

            _fisService = fisService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CariFisEkle(int cariId, FisDto ajaxData)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().Distinct();
                return BadRequest(JsonConvert.SerializeObject(errors));
            }

            if (Request.IsAjaxRequest())
            {
                await _fisService.CariFisEkleAsync(_mapper.Map<Fis>(ajaxData), new User { Id = 1, AdSoyad = "Anıl OĞRAŞ" }, cariId);
                return PartialView("~/Views/Fis/FisListPartial.cshtml", _fisService.CariFisleri(cariId).PagedList(_mapper.Map<IEnumerable<Fis>, IEnumerable<FisDto>>, 1, 10));
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> FisDetay(int id)
        {
            var fisDetay = _mapper.Map<FisDto>(await _fisService.FisGetirFullData(id));

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Fis/FisDetayContentPartial.cshtml", fisDetay);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> FisDuzenle(FisDto ajaxData, int cariId)
        {
            if (Request.IsAjaxRequest())
            {
                var result = await _fisService.FisDuzenle(_mapper.Map<Fis>(ajaxData));
                if (result)
                {
                    return PartialView("~/Views/Fis/FisListPartial.cshtml", _fisService.CariFisleri(cariId).PagedList(_mapper.Map<IEnumerable<Fis>, IEnumerable<FisDto>>, 1, 10));
                }
                else
                {
                    return BadRequest(new JsonError { Error = "Fiş Düzenleme İşlemi Başarısız..." });
                }

            }

            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> FisSil(int id, int cariId)
        {

            if (Request.IsAjaxRequest())
            {
                _fisService.Delete(new Fis { Id = id });
                await _fisService.SaveChangeAsync();
                return PartialView("~/Views/Fis/FisListPartial.cshtml", _fisService.CariFisleri(cariId).PagedList(_mapper.Map<IEnumerable<Fis>, IEnumerable<FisDto>>, 1, 10));
            }

            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult FisListPartial()
        {
            return PartialView();
        }


    }
}

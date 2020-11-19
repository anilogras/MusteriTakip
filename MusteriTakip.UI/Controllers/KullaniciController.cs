using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusteriTakip.Business.Services;
using MusteriTakip.DTOs.KullaniciDtos;
using MusteriTakip.Entities.Concrete;
using MusteriTakip.UI.Extensions;
using MusteriTakip.UI.Model;
using Newtonsoft.Json;

namespace MusteriTakip.UI.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class KullaniciController : Controller
    {
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public KullaniciController(IUserServices userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Kullanicilar(int? page)
        {
            var data = _userService.GetUserWithRoles().ToList();
            KullaniciViewModel model = new KullaniciViewModel()
            {
                Kullanicilar = _userService.GetUserWithRoles().PagedList(_mapper.Map<IEnumerable<User>, IEnumerable<KullaniciListDto>>, page ?? 1)
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("KullaniciListPartial", model.Kullanicilar);
            }

            return View(model);
        }

        public async Task<IActionResult> KullaniciEkle(KullaniciListDto ajaxData)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().Distinct();
                return BadRequest(JsonConvert.SerializeObject(errors));
            }

            if (Request.IsAjaxRequest())
            {
                var result = await _userService.UserAdd(_mapper.Map<User>(ajaxData), _mapper.Map<List<Role>>(ajaxData.Roller), ajaxData.Sifre);

                if (!result.Success)
                {
                    return BadRequest(JsonConvert.SerializeObject(result.Errors));
                }

                return PartialView("KullaniciListPartial", _userService.GetUserWithRoles().PagedList(_mapper.Map<IEnumerable<User>, IEnumerable<KullaniciListDto>>));
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> KullaniciSil(int id)
        {
            if (Request.IsAjaxRequest())
            {
                await _userService.UserDelete(new User { Id = id });
                return PartialView("KullaniciListPartial", _userService.GetUserWithRoles().PagedList(_mapper.Map<IEnumerable<User>, IEnumerable<KullaniciListDto>>));
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Giris()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Giris(KullaniciLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await  _userService.UserLogin(model.UserName, model.Password, model.RememberMe);
            
            return RedirectToAction("Index", "Home");
        }

    }
}

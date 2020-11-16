using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusteriTakip.Business.Services;
using Newtonsoft.Json;

namespace MusteriTakip.UI.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class KdvController : Controller
    {
        private readonly IKDVService _kdvService;

        public KdvController(IKDVService kdvService)
        {
            _kdvService = kdvService;
        }

        public async Task<IActionResult> Kdvler()
        {
            var kdvler = JsonConvert.SerializeObject(await _kdvService.GetAllAsync());
            return Json(kdvler);
        }
    }
}

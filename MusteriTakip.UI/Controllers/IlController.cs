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
    public class IlController : Controller
    {
        private readonly IIlService _ilService;
        private readonly IIlceService _ilceService;

        public IlController(IIlService ilService, IIlceService ilceService)
        {
            _ilService = ilService;
            _ilceService = ilceService;
        }

        public async Task<JsonResult> IlGetir()
        {
            return Json(JsonConvert.SerializeObject(await _ilService.GetAllAsync()));
        }

        public JsonResult IlceGetir(int id)
        {
            var data = _ilceService.GetByIlceWithIlId(id);
            return Json(JsonConvert.SerializeObject(data));
        }
    }
}

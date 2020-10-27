using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusteriTakip.Business.Services;
using MusteriTakip.DTOs.KullaniciDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Controllers
{
    public class YetkiController : Controller
    {
        private readonly IRoleServices _appRoleService;
        private readonly IMapper  _mapper;

        public YetkiController(IRoleServices appRoleService, IMapper mapper)
        {
            _appRoleService = appRoleService;
            _mapper = mapper;
        }

        public JsonResult YetkiGetir()
        {
            var data = _mapper.Map<List<RoleListDto>>(_appRoleService.GetAllRole());
            return Json(JsonConvert.SerializeObject(data));
        }


    }
}

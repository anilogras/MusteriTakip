using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.KullaniciDtos
{
    public class RoleListDto
    {
        public List<UserRoleListDto> UserRoles { get; set; }
        public string RolAdi { get; set; }
        public string Name { get; set; }
    }
}

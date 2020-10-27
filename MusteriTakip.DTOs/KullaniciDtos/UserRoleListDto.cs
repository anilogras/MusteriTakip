using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.KullaniciDtos
{
    public class UserRoleListDto
    {
        public virtual KullaniciListDto Kullanici { get; set; }
        public virtual RoleListDto Rol { get; set; }
    }
}

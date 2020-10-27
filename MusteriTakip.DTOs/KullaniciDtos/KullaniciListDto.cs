using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DTOs.KullaniciDtos
{
    public class KullaniciListDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public bool Aktif { get; set; }
        public char Cinsiyet { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrar { get; set; }
        public List<UserRoleListDto> UserRoles { get; set; }
        public List<RoleListDto> Roller { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Entities.Concrete
{
    public class User : IdentityUser<int>, ITable
    {
        public User()
        {
            Fislers = new List<Fis>();
        }

        public string AdSoyad { get; set; }
        public bool Aktif { get; set; }
        public char Cinsiyet { get; set; }
        public virtual List<Fis> Fislers { get; set; }


        public List<UserRole> UserRoles { get; set; }
    }
}

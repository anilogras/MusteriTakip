using Microsoft.AspNetCore.Identity;
using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Entities.Concrete
{
    public class Role :IdentityRole<int>, ITable
    {
        public List<UserRole> UserRoles { get; set; }
        public string RolAdi { get; set; }
    }
}

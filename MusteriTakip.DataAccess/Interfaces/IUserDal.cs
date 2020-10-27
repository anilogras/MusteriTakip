using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.DataAccess.Interfaces
{
    public interface IUserDal
    {
        IQueryable<User> GetUserWithRoles();
        Task<User> GetUserByIdAsync(int id);
        IQueryable<Fis> GetUserFis(int id);
        Task UserChangeStatus(int id);
    }
}

using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Services
{
    public interface IRoleServices
    {
        Task<bool> AddRole(Role role);
        Task<bool> RemoveRole(Role role);
        Task<Role> FindById(int id);
        Task<Role> FindByName(string name);
        List<Role> GetAllRole();
    }
}

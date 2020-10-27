using Microsoft.AspNetCore.Identity;
using MusteriTakip.Business.Services;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Concrete
{
    public class AppRoleManager : IRoleServices
    {

        private readonly RoleManager<Role> _roleManager;

        public AppRoleManager(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> AddRole(Role role)
        {
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> RemoveRole(Role role)
        {
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<Role> FindById (int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<Role> FindByName(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public List<Role> GetAllRole()
        {
            return _roleManager.Roles.ToList();
        }


    }
}

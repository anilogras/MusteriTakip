using Microsoft.AspNetCore.Identity;
using MusteriTakip.Business.ReturnTypes;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Services
{
    public interface IUserServices
    {

        Task<AppUserResult> UserAdd(User user, string password);
        Task<AppUserResult> UserAdd(User user, List<Role> roles, string password);
        Task<AppUserResult> UserDelete(User user);
        Task<AppUserResult> UserAddRole(User user, string role);
        Task<AppUserResult> UserAddRole(User user, List<string> role);
        Task<AppUserResult> UserDeleteRole(User user, string role);
        Task<AppUserResult> UserDeleteRole(User user, List<string> role);

        Task<User> UserGetById(Claim nameIdentifier);
        List<User> UserGetAll();
        IQueryable<User> GetUserWithRoles();
        User GetUserWithEMail(string eMail);

        Task<User> GetUserByIdAsync(int id);
        IQueryable<Fis> GetUserFis(int id);
        Task UserChangeStatus(int id);
        Task<AppUserLoginResult> UserLogin(string userName, string password, bool persistent);
    }
}
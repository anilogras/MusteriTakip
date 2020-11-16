using Microsoft.AspNetCore.Identity;
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

        Task<IdentityResult> UserAdd(User user, string password);
        Task<IdentityResult> UserAdd(User user, List<Role> roles, string password);
        Task<bool> UserDelete(User user);
        Task<bool> UserAddRole(User user, string role);
        Task<bool> UserAddRole(User user, List<string> role);
        Task<bool> UserDeleteRole(User user, string role);
        Task<bool> UserDeleteRole(User user, List<string> role);

        Task<User> UserGetById(Claim nameIdentifier);
        List<User> UserGetAll();
        IQueryable<User> GetUserWithRoles();
        User GetUserWithEMail(string eMail);

        Task<User> GetUserByIdAsync(int id);
        IQueryable<Fis> GetUserFis(int id);
        Task UserChangeStatus(int id);
        Task<SignInResult> UserLogin(string userName, string password, bool persistent);
    }
}
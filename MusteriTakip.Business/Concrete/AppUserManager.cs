using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusteriTakip.Business.ReturnTypes;
using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Concrete
{
    public class UserManager : IUserServices
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserDal _userDal;

        public UserManager(UserManager<User> userManager, IUserDal userDal, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _userDal = userDal;
            _signInManager = signInManager;
        }


        public async Task<AppUserResult> UserAdd(User user, string password)
        {
            AppUserResult info = new AppUserResult();
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("adsoyad", user.AdSoyad));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
                await _userManager.AddToRoleAsync(user, "Member");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                    info.Success = false;
                }
            }

            return info;
        }
        public async Task<AppUserResult> UserAdd(User user,List<Role> roles, string password)
        {
            AppUserResult info = new AppUserResult();
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("adsoyad", user.AdSoyad));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
                if(roles.Count != 0)
                {
                    foreach (var role in roles)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                }
            }
            return info;
        }
        public async Task<AppUserResult> UserDelete(User user)
        {
            AppUserResult info = new AppUserResult();
            var deletedUser = await GetUserByIdAsync(user.Id);

            if(deletedUser == null)
            {
                info.Success = false;
                info.Errors.Add("Silinecek Kullanıcı Bulunamadı.");
            }


            await _userManager.RemoveClaimsAsync(deletedUser, await _userManager.GetClaimsAsync(deletedUser));
            var result = await _userManager.DeleteAsync(deletedUser);

            if (!result.Succeeded)
            {
                info.Success = false;
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                }
            }

            return info;
        }


        public async Task<AppUserResult> UserAddRole(User user , string role)
        {
            AppUserResult info = new AppUserResult();
            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                info.Success = false;
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                }
            }
            return info;
        }
        public async Task<AppUserResult> UserAddRole(User user, List<string> role)
        {
            AppUserResult info = new AppUserResult();
            var result = await _userManager.AddToRolesAsync(user, role);
            if (!result.Succeeded)
            {
                info.Success = false;
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                }
            }
            return info;
        }
        public async Task<AppUserResult> UserDeleteRole(User user , string role)
        {
            AppUserResult info = new AppUserResult();
            var result = await _userManager.RemoveFromRoleAsync(user, role);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                }
            }

            return info;
        }
        public async Task<AppUserResult> UserDeleteRole(User user, List<string> role)
        {
            AppUserResult info = new AppUserResult();
            var result = await _userManager.AddToRolesAsync(user, role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    info.Errors.Add(error.Description);
                }
            }

            return info;
        }
        public async Task<User> UserGetById(Claim nameIdentifier)
        {
            return await _userManager.FindByNameAsync(nameIdentifier.Value);
        }
        public List<User> UserGetAll()
        {
            return _userManager.Users.Where(x=>x.Aktif == true).ToList();
        }
        public IQueryable<User> GetUserWithRoles()
        {
          return _userDal.GetUserWithRoles();
        }
        public  async Task<User> GetUserByIdAsync(int id)
        {
            return await _userDal.GetUserByIdAsync(id);
        }
        public IQueryable<Fis> GetUserFis(int id)
        {
            return _userDal.GetUserFis(id);
        }
        public async Task UserChangeStatus(int id)
        {
           await _userDal.UserChangeStatus(id);
        }
        public User GetUserWithEMail(string eMail)
        {
            return _userManager.Users.FirstOrDefault(x => x.Email == eMail);
        }
        public async Task<AppUserLoginResult> UserLogin(string userName , string password , bool persistent)
        {
            AppUserLoginResult info = new AppUserLoginResult();
            var userNameCheck = _userManager.Users.FirstOrDefault(x => x.UserName == userName);

            if(userNameCheck == null)
            {
                info.Success = false;
                info.Errors.Add("Kullanıcı Adı veya Şifre Hatalı");
                return info;
            }

            var loginResult = await _signInManager.PasswordSignInAsync(userName, password, persistent, false);

            if(!loginResult.Succeeded)
            {
                info.Success = false;
                info.Errors.Add("Kullanıcı Adı veya Şifre Hatalı");
            }

            return info;
        }
    }
}

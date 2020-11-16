using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IdentityResult> UserAdd(User user, string password)
        {
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.AdSoyad));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
                await _userManager.AddToRoleAsync(user, "Member");
            }
            return result;
        }
        public async Task<IdentityResult> UserAdd(User user,List<Role> roles, string password)
        {
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.AdSoyad));
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
            return result;
        }
        public async Task<bool> UserDelete(User user)
        {
            var deletedUser =await GetUserByIdAsync(user.Id);
            await _userManager.RemoveClaimsAsync(deletedUser, await _userManager.GetClaimsAsync(deletedUser));
            var result = await _userManager.DeleteAsync(deletedUser);
            return result.Succeeded;
        }
        public async Task<bool> UserAddRole(User user , string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }
        public async Task<bool> UserAddRole(User user, List<string> role)
        {
            var result = await _userManager.AddToRolesAsync(user, role);
            return result.Succeeded;
        }
        public async Task<bool> UserDeleteRole(User user , string role)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }
        public async Task<bool> UserDeleteRole(User user, List<string> role)
        {
            var result = await _userManager.AddToRolesAsync(user, role);
            return result.Succeeded;
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
        public async Task<SignInResult> UserLogin(string userName , string password , bool persistent)
        {
           return await _signInManager.PasswordSignInAsync(userName , password, persistent , false);
        }
    }
}

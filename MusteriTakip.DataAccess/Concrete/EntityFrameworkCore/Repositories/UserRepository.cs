using Microsoft.EntityFrameworkCore;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class UserRepository :GenericRepository<User>, IUserDal
    {

        private readonly MusteriTakipContext _context;

        public UserRepository(MusteriTakipContext context):base(context)
        {
            _context = context;
        }

        public IQueryable<User> GetUserWithRoles()
        {
            return _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).Include(x=>x.UserRoles).ThenInclude(x=>x.User).AsQueryable();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Set<User>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<Fis> GetUserFis(int id)
        {
            return _context.Set<Fis>().Where(x => x.UserId == id)
                .Include(x=>x.Cari)
                .Include(x => x.FisOzelliks);
        }

        public async Task UserChangeStatus(int id)
        {
            var user = _context.Set<User>().Where(x => x.Id == id).FirstOrDefault();
            if (user.Aktif == true)
                user.Aktif = false;
            else
                user.Aktif = true;
            await  _context.SaveChangesAsync();
            
        }
    }
}

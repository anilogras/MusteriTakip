using Microsoft.EntityFrameworkCore;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class FisRepository : GenericRepository<Fis>, IFisDal
    {
        private readonly MusteriTakipContext _context;
        public FisRepository(MusteriTakipContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Fis> CariFisleri(int id)
        {
            return _context.Set<Fis>().Where(x => x.CariId == id)
                .Include(x => x.FisOzelliks)
                .Include(x => x.User)
                .Include(x=>x.Cari)
                .AsQueryable();
        }

        public IQueryable<Fis> KullaniciFisleri(int id)
        {
            return _context.Set<Fis>().Where(x=>x.UserId == id)
                .Include(x=>x.FisOzelliks)
                .Include(x => x.User)
                .Include(x => x.Cari)
                .AsQueryable();
        }

        public async Task<Fis> FisGetirFullData(int id)
        {
            return await _context.Set<Fis>().Where(x => x.Id == id)
                      .Include(x => x.FisOzelliks)
                .Include(x => x.User)
                .Include(x => x.Cari)
                .FirstOrDefaultAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CariRepository : GenericRepository<Cari>, ICariDal
    {
        private readonly MusteriTakipContext _context;

        public CariRepository(MusteriTakipContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Cari> GetCarisForList()
        {
            return _context.Set<Cari>()
                .Include(x => x.CariEMails)
                .Include(x => x.CariTelefons)
                .Include(x => x.CariCeps)
                .Include(x => x.CariAdreslers).ThenInclude(x => x.Il)
                .Include(x => x.CariAdreslers).ThenInclude(x => x.Ilce)
                .Include(x => x.CariAdreslers)
                .AsQueryable();
        }

        public IQueryable<Cari> GetCarisAllData()
        {
            return _context.Set<Cari>()
                .Include(x => x.CariAdreslers).ThenInclude(x=>x.Il)
                .Include(x=>x.CariAdreslers).ThenInclude(x=>x.Ilce)
                .Include(x=>x.CariAdreslers)
                .Include(x => x.CariCeps)
                .Include(x => x.CariEMails)
                .Include(x => x.CariFaxes)
                .Include(x => x.CariTelefons)
                .Include(x => x.CariVd)
                .Include(x => x.CariWebSites)
                .AsQueryable();
        }
    }
}

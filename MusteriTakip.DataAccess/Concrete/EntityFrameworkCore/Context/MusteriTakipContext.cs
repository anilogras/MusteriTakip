using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class MusteriTakipContext :IdentityDbContext<User,Role,int,IdentityUserClaim<int>,UserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =.;initial catalog =MusteriTakipDb;integrated security =true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CariAdresMap());
            modelBuilder.ApplyConfiguration(new CariMap());
            modelBuilder.ApplyConfiguration(new CariVdMap());
            modelBuilder.ApplyConfiguration(new FislerMap());
            modelBuilder.ApplyConfiguration(new FisOzellikMap());
            modelBuilder.ApplyConfiguration(new KDVMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CariCepMap());
            modelBuilder.ApplyConfiguration(new CariEmailMap());
            modelBuilder.ApplyConfiguration(new CariFaxMap());
            modelBuilder.ApplyConfiguration(new CariTelefonMap());
            modelBuilder.ApplyConfiguration(new CariWebSiteMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }


        public DbSet<Cari> Caris { get; set; }
        public DbSet<CariAdres> CariAdresCaris { get; set; }
        public DbSet<CariCep> CariIletisims { get; set; }
        public DbSet<CariVd> CariVds { get; set; }
        public DbSet<Fis> Fislers { get; set; }
        public DbSet<FisOzellik> FisOzelliks { get; set; }
        public DbSet<KDV> KDVs { get; set; }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Role> AppRoles { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }

        public DbSet<CariWebSite> CariWebSites { get; set; }
        public DbSet<CariCep> CariCeps { get; set; }
        public DbSet<CariEMail> CariEMails { get; set; }
        public DbSet<CariFax> CariFaxes { get; set; }
        public DbSet<CariTelefon> CariTelefons { get; set; }
    }
}

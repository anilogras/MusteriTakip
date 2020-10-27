using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
     public class CariMap : IEntityTypeConfiguration<Cari>
    {
        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsletmeAdi).IsRequired().HasMaxLength(100);

            builder.Property(x => x.IsletmeYetkilisi).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Aciklama).HasColumnType("nvarchar(250)");

            builder.Property(x => x.Aktif).HasDefaultValue(true);

            builder.HasMany(x => x.Fislers)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CariAdreslers)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CariCeps)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CariEMails)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CariFaxes)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CariTelefons)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CariWebSites)
                .WithOne(x => x.Cari)
                .HasForeignKey(x => x.CariId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

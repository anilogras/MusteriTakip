using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CariAdresMap : IEntityTypeConfiguration<CariAdres>
    {
        public void Configure(EntityTypeBuilder<CariAdres> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Adres).HasMaxLength(250);

            builder.HasOne(x => x.Il)
                .WithMany(x => x.Adres)
                .HasForeignKey(x => x.IlId);

            builder.HasOne(x => x.Ilce)
                .WithMany(x => x.Adres)
                .HasForeignKey(x => x.IlceId);
                
        }
    }
}

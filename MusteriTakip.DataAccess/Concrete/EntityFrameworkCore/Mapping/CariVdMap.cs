using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CariVdMap : IEntityTypeConfiguration<CariVd>
    {
        public void Configure(EntityTypeBuilder<CariVd> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Unvan).HasMaxLength(100);

            builder.Property(x => x.VDNo).HasColumnType("char(11)");

            builder.Property(x => x.VdDairesi).HasMaxLength(30);
        }
    }
}

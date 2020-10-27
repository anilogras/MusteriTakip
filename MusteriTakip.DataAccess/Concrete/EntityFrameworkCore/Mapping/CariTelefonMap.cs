using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CariTelefonMap : IEntityTypeConfiguration<CariTelefon>
    {
        public void Configure(EntityTypeBuilder<CariTelefon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Telefon).HasColumnType("char(11)");
        }
    }
}

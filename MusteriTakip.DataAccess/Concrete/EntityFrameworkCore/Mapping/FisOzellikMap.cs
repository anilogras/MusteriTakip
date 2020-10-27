using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class FisOzellikMap : IEntityTypeConfiguration<FisOzellik>
    {
        public void Configure(EntityTypeBuilder<FisOzellik> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Tanim).HasMaxLength(20);

            builder.Property(x => x.Aciklama).HasMaxLength(50);

            builder.Property(x => x.Olcu).HasMaxLength(20);
        }
    }
}

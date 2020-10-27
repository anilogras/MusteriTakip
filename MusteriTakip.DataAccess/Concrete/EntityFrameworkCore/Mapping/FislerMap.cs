using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class FislerMap : IEntityTypeConfiguration<Fis>
    {
        public void Configure(EntityTypeBuilder<Fis> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FisNot).HasMaxLength(50);

            builder.Property(x => x.Faturalandir).HasDefaultValue(false);

            builder.Property(x => x.FisKullanicisi).IsRequired().HasMaxLength(40);

            builder.Property(x => x.Silindimi).HasDefaultValue(false);

            builder.HasMany(x => x.FisOzelliks)
                .WithOne(x => x.Fis)
                .HasForeignKey(x => x.FisId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

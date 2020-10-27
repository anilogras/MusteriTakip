using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.AdSoyad).IsRequired().HasMaxLength(40);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);


            builder.Property(x => x.Aktif).HasDefaultValue(true);

            builder.Property(x => x.Cinsiyet).HasColumnType("char(1)");

            builder.HasMany(x => x.Fislers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}

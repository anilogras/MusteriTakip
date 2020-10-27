using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusteriTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CariCepMap : IEntityTypeConfiguration<CariCep>
    {
        public void Configure(EntityTypeBuilder<CariCep> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Cep).HasColumnType("char(11)");
    }
    }
}

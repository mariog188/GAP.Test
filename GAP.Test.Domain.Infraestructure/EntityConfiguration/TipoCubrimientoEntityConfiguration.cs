using GAP.Test.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Infraestructure.EntityConfiguration
{
    public class TipoCubrimientoEntityConfiguration : IEntityTypeConfiguration<TipoCubrimiento>
    {
        public void Configure(EntityTypeBuilder<TipoCubrimiento> builder)
        {
            builder.ToTable("tipocubrimiento");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(30)
                   .IsRequired();
        }
    }
}

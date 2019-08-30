using GAP.Test.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Infraestructure.EntityConfiguration
{
    public class TipoRiesgoEntityConfiguration : IEntityTypeConfiguration<TipoRiesgo>
    {
        public void Configure(EntityTypeBuilder<TipoRiesgo> builder)
        {
            builder.ToTable("tiporiesgo");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(30)
                   .IsRequired();
        }
    }
}

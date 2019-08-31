using GAP.Test.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Infraestructure.EntityConfiguration
{
    public class PolizaEntityConfiguration : IEntityTypeConfiguration<Poliza>
    {
        public void Configure(EntityTypeBuilder<Poliza> builder)
        {
            builder.ToTable("poliza");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Nombre)
                   .HasColumnName("nombre")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(item => item.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(item => item.FechaInicio)
                   .HasColumnName("fechainicio")
                   .HasDefaultValue()
                   .IsRequired();

            builder.Property(item => item.PeriodoCobertura)
                   .HasColumnName("periodocobertura")
                   .IsRequired();

            builder.Property(item => item.Precio)
                   .HasColumnName("precio")
                   .IsRequired();

            builder.HasOne(item => item.TipoCubrimiento)
                   .WithMany(item => item.Polizas)
                   .HasForeignKey(item => item.IdTipoCubrimiento);

            builder.HasOne(item => item.TipoRiesgo)
                   .WithMany(item => item.Polizas)
                   .HasForeignKey(item => item.IdTipoRiesgo);

            builder.HasOne(item => item.Cliente)
                   .WithMany(item => item.Polizas)
                   .HasForeignKey(item => item.IdCliente);
        }
    }
}

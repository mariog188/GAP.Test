using GAP.Test.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Infraestructure.EntityConfiguration
{
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Nombre)
                   .HasColumnName("nombre")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(item => item.Apellido)
                   .HasColumnName("apellido")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(item => item.Cedula)
                      .HasColumnName("cedula")
                      .IsRequired();

            builder.Property(item => item.FechaNacimiento)
                      .HasColumnName("fechanacimiento")
                      .IsRequired();

            //builder.HasMany(item => item.Polizas)
            //    .WithOne(item => item.Cliente)
            //    .HasForeignKey(item => item.IdCliente);
        }
    }
}

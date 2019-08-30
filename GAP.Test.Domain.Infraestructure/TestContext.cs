using GAP.Test.Domain.Core.Contracts;
using GAP.Test.Domain.Infraestructure.EntityConfiguration;
using GAP.Test.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Infraestructure
{
    public class TestContext : DbContext, IDbContext
    {
        #region DB Sets
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<TipoCubrimiento> TiposCubrimientos { get; set; }
        public DbSet<TipoRiesgo> TiposRiesgos { get; set; }

        #endregion

        #region Configuration

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PolizaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TipoCubrimientoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TipoRiesgoEntityConfiguration());
        }

        #endregion Configuration
    }
}

using GAP.Test.Domain.Infraestructure;
using GAP.Test.Front.Infrastructure.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Infrastructure
{
    public static class TestContextSeed
    {
        /// <summary>
        /// checks if a migration can be applied
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                                     .GetAppliedMigrations()
                                     .Select(migration => migration.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                               .Migrations
                               .Select(migration => migration.Key);

            return !total.Except(applied).Any();
        }

        /// <summary>
        /// Get the seed to fill the databasse
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="environment"></param>
        /// <param name="logger"></param>
        public static void EnsureSeed(this TestContext context, IHostingEnvironment environment, ILogger logger)
        {
            var seedPolicy = CreateSeedPolicy(logger, nameof(TestContextSeed));

            seedPolicy.Execute(() =>
            {

                if (!context.Clientes.Any())
                {
                    context.Clientes.AddRange(ClienteSeed.GetSampleCliente() );
                }

                if (!context.TiposCubrimientos.Any())
                {
                    context.TiposCubrimientos.AddRange(TipoCubrimientoSeed.GetSampleTipoCubrimiento());
                }

                if (!context.TiposRiesgos.Any())
                {
                    context.TiposRiesgos.AddRange(TipoRiesgoSeed.GetSampleTipoRiesgo());
                }
                context.SaveChangesAsync();
            });
        }

        private static Policy CreateSeedPolicy(ILogger logger, string prefix, short retries = 3)
        {
            return Policy.Handle<MySqlException>()
                .WaitAndRetry(
                        retryCount: retries,
                        sleepDurationProvider: retry => TimeSpan.FromSeconds(10),
                        onRetry: (exception, timeSpan, retry, ctx) => logger.LogTrace($"[{prefix}] Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}")
                    );
        }
    }
}

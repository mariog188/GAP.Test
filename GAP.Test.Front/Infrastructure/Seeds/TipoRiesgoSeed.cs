using GAP.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Infrastructure.Seeds
{
    public static class TipoRiesgoSeed
    {
        internal static IEnumerable<TipoRiesgo> GetSampleTipoRiesgo()
        {
            return new List<TipoRiesgo>()
            {
                new  TipoRiesgo() {Id =1, Descripcion = "bajo" },
                new  TipoRiesgo() {Id =2, Descripcion = "medio" },
                new  TipoRiesgo() {Id =3, Descripcion = "medio-alto" },
                new  TipoRiesgo() {Id =4, Descripcion = "alto" },
            };
        }
    }
}
using GAP.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Infrastructure.Seeds
{
    public static class TipoCubrimientoSeed
    {
        internal static IEnumerable<TipoCubrimiento> GetSampleTipoCubrimiento()
        {
            return new List<TipoCubrimiento>()
            {
                new TipoCubrimiento() {Id =1, Descripcion = "Terremoto", Porcentaje = 10 },
                new TipoCubrimiento() {Id =2, Descripcion = "incendio", Porcentaje = 30 },
                new TipoCubrimiento() {Id =3, Descripcion = "robo", Porcentaje = 50 },
                new TipoCubrimiento() {Id =4, Descripcion = "perdida", Porcentaje = 60 },

            };
        }
    }
}
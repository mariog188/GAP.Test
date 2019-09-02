using GAP.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Infrastructure.Seeds
{
    public static class PolizaSeed
    {
        internal static IEnumerable<Poliza> GetSamplePoliza()
        {
            return new List<Poliza>()
            {
                new Poliza() {Id = 1,Descripcion = "Poliza 1", IdCliente = 1, FechaInicio = new DateTime(1999,01,02), IdTipoCubrimiento =1, IdTipoRiesgo = 1, Nombre = "Poliza 1", PeriodoCobertura = 12, Precio = 123000,  },

            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.ViewModel
{
    public class PolizaVM
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int PeriodoCobertura { get; set; }
        public decimal Precio { get; set; }
        public int IdTipoCubrimiento { get; set; }
        public int IdTipoRiesgo { get; set; }
        public int IdCliente { get; set; }
    }
}

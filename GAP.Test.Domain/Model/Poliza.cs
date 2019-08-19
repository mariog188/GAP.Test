using GAP.Test.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Model
{
    public class Poliza : Entity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int PeriodoCobertura { get; set; }
        public decimal Precio { get; set; }
        public int IdTipoCubrimiento { get; set; }
        public virtual TipoCubrimiento TipoCubrimiento { get; set; }
        public int IdTipoRiesgo { get; set; }
        public virtual TipoRiesgo TipoRiesgo { get; set; }
    }
}

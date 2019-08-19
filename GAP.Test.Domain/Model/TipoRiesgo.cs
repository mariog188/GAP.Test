using GAP.Test.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Model
{
    public class TipoRiesgo : Entity<int>
    {
        public string Descripcion { get; set; }
        public ICollection<Poliza> Polizas { get; set; }
    }
}

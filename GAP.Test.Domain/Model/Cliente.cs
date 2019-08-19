using GAP.Test.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Test.Domain.Model
{
    public class Cliente : Entity<int>
    {
        public string  Nombre { get; set; }

        public string Apellidp { get; set; }

        public int Cedula { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}

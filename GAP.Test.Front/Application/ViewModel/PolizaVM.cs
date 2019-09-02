using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.ViewModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PolizaVM
    {
        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonProperty(PropertyName = "PeriodoCobertura")]
        public int PeriodoCobertura { get; set; }

        [JsonProperty(PropertyName = "Precio")]
        public decimal Precio { get; set; }

        [JsonProperty(PropertyName = "TipoCobertura")]
        public int IdTipoCubrimiento { get; set; }

        [JsonProperty(PropertyName = "TipoRiesgo")]
        public int IdTipoRiesgo { get; set; }

        [JsonProperty(PropertyName = "Cedula")]
        public int IdCliente { get; set; }

        [JsonProperty(PropertyName = "IdPoliza")]
        public int Id { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.ViewModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TipoRiesgoVM
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Nombre")]
        public string Descripcion { get; set; }
    }
}

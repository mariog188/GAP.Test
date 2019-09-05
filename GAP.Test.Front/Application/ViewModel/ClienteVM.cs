using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Application.ViewModel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClienteVM
    {
        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Apellido")]
        public string Apellido { get; set; }

        [JsonProperty(PropertyName = "Cedula")]
        public int Cedula { get; set; }
    }
}

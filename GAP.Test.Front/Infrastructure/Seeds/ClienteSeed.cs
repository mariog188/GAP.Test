using GAP.Test.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Test.Front.Infrastructure.Seeds
{
    public static class ClienteSeed
    {
        internal static IEnumerable<Cliente> GetSampleCliente()
        {
            return new List<Cliente>()
            {
                new Cliente() {Id = 1, Apellido = "Gutierrez", Cedula = 123456, FechaNacimiento = new DateTime(1988,07,07) , Nombre = "Mario" },
                new Cliente() {Id = 2, Apellido = "Isaza", Cedula = 1234446, FechaNacimiento = new DateTime(1988,08,08) , Nombre = "Alejandro" },
                new Cliente() {Id = 3, Apellido = "Urrego", Cedula = 123555, FechaNacimiento = new DateTime(1989,02,07) , Nombre = "Andrea" },
                new Cliente() {Id = 4, Apellido = "Arcila", Cedula = 123466, FechaNacimiento = new DateTime(1988,01,07) , Nombre = "Maria" },
            };
        }
    }
}

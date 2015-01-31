using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad01.Data.Entities
{
    public class Pasajero: RepositoryEntity
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string CiudadOrigen { get; set; }

        public string CiudadDestino { get; set; }

        public int Asiento { get; set; }
        public override string ToString()
        {

            return string.Format("Pasajero {0}",Id);
        }
    }
}

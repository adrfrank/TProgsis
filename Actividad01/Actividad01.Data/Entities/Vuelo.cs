
using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad01.Data.Entities
{
    public class Vuelo : RepositoryEntity
	{

        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaArribo { get; set; }
        public int DistanciaVuelo { get; set; }
        public int CapacidadPasajeros { get; set; }
        public int CapacidadCarga { get; set; }
        public int AsientosDisponibles { get; set; }
	}
}


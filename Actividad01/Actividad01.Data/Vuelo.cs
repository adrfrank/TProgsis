
using System;

namespace Actividad01.Data
{
	public class Vuelo
	{
		public Vuelo ()
		{
		}

		public int Id {
			get;
			set;
		}

		public string Nombre {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[Vuelos: Id={0}, Nombre={1}]", Id, Nombre);
		}
	}
}


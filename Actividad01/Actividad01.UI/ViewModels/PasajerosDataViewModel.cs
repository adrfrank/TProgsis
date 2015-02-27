using Actividad01.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Actividad01.UI.ViewModels
{
    public class PasajerosDataViewModel
    {
        public ICollectionView Pasajeros { get; private set; }
        public PasajerosDataViewModel(List<Pasajero> pasajero)
        {
            Pasajeros = new ListCollectionView(pasajero);
        }
    }
}

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
    public class VuelosDataViewModel
    {
        public ICollectionView Vuelos { get; private set; }
        public VuelosDataViewModel(List<Vuelo> vuelos)
        {
            Vuelos = new ListCollectionView(vuelos);
        }
    }
}

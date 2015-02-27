using Actividad01.Data;
using Actividad01.Data.Entities;
using AdrfrankLibrary.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Actividad01.UI.ViewModels
{
    public class VuelosViewModel
    {
        public ICollectionView Vuelos { get; private set; }
        IRepository<Vuelo> repository;

        public VuelosViewModel(IRepository<Vuelo> repository) {
            this.repository = repository;
            Vuelos = new ListCollectionView(repository.FetchAll());
            SaveCommand = new ActionCommand(Save);
            FechaSortCommand = new ActionCommand(FechaSort);
            AsientosSortCommand = new ActionCommand(AsientosSort);
        }


        public ActionCommand SaveCommand { get; set; }

        public ActionCommand FechaSortCommand { get; set; }
        public ActionCommand AsientosSortCommand { get; set; }

        void Save() {
           
            repository.Save();
            //Reload();
        }

        void FechaSort() {
            repository.Save();

            var vlist = repository.FetchAll().MergeSort(x => x.FechaSalida).ToList();
            var form = new VuelosListWindow();
            form.ViewModel = new VuelosDataViewModel(vlist);
            form.Show();
            
        }
        void AsientosSort()
        {
            repository.Save();
            var l = repository.FetchAll();
            var vlist = l.MergeSort(x => x.AsientosDisponibles).ToList();
            var form = new VuelosListWindow();
            form.ViewModel = new VuelosDataViewModel(vlist);
            form.Show();
            
        }

        public void Reload()
        {
            Vuelos = new ListCollectionView(repository.FetchAll());
            Vuelos.Refresh();

        }


    }
}

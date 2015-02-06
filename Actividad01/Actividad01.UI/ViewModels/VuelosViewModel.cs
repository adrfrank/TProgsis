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
        }

        public ActionCommand SaveCommand { get; set; }

        void Save() {
           
            repository.Save();
            //Reload();
        }

        public void Reload()
        {
            Vuelos = new ListCollectionView(repository.FetchAll());
        }
    }
}

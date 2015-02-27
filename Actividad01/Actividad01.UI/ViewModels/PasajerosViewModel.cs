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
    public class PasajerosViewModel
    {
        public ICollectionView Items { get; private set; }
        IRepository<Pasajero> repository;

        public PasajerosViewModel(IRepository<Pasajero> repository)
        {
            this.repository = repository;
            Items = new ListCollectionView(repository.FetchAll());
            SaveCommand = new ActionCommand(Save);
            SearchCommand = new ActionCommand(Search);
        }

        public ActionCommand SaveCommand { get; set; }
        public ActionCommand SearchCommand { get; set; }

        void Save() {
           
            repository.Save();
            //Reload();
        }

        void Search() { 
        
        }
        public void Reload() {
            Items = new ListCollectionView(repository.FetchAll());
        }
    }
}

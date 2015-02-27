using Actividad01.Data;
using Actividad01.Data.Entities;
using AdrfrankLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.UI.ViewModels
{
    public class PasajeroSearchViewModel
    {
        public string SearchTerm { get; set; }

        public ActionCommand SearchCommand { get; set; }

        public IRepository<Pasajero> Repository { get; set; }

        public PasajeroSearchViewModel(IRepository<Pasajero> repository)
        {
            Repository = repository;
            SearchCommand = new ActionCommand(searchAndShow);
        }

        void searchAndShow(){
            var d = Repository.FetchAll().ToArray();
            var tree = Actividad01.Data.Util.BinaryTreeList<Pasajero>.FromArray(d, p => p.Apellido);
            List<Pasajero> founds = tree.FindList(this.SearchTerm) ?? new List<Pasajero>();
            var form = new PasajerosListWindow();
            var vm = new PasajerosDataViewModel(founds);
            form.ViewModel = vm;
            form.Show();
        }
    }
}

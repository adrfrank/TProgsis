using System;
using Actividad01.Data;
using Actividad01.Data.Entities;
using System.Collections.Generic;
using Gtk;

namespace Actividad01
{
	public partial class PasajerosListWindow : Gtk.Window
	{
		IRepository<Pasajero> Repository { get; set; }
		bool structureLoaded = false;

		public PasajerosListWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			Repository = new FileRepositoryFactory ().CreatePasajeroRepository ();
			LoadData ();
			//Actions
			addAction.Activated += addAction_Activated;
		}

		void addAction_Activated (object sender, EventArgs e)
		{
			System.Console.WriteLine("Add");
		}

		protected void LoadData(){
			List<Pasajero> DataItems = Repository.FetchAll ();
			Type entityType = DataItems.Count > 0 ? DataItems [0].GetType () : null;
			var liststore = new Gtk.ListStore (entityType);
			foreach (var item in DataItems) {
				liststore.AppendValues (item);
			}
			loadTableStructure (entityType);
			tvwDatos.Model = liststore;
		}

		protected virtual void loadTableStructure(Type entityType,bool force=false){
			if (entityType!= null &&(!structureLoaded || force)) {
				structureLoaded = true;
				var properties = entityType.GetProperties ();
				foreach (var prop in properties) {
					var column = new TreeViewColumn ();
					column.Title = prop.Name;
					var cell = new CellRendererText ();
					column.PackStart (cell, true);
					tvwDatos.SelectCursorRow += HandleSelectCursorRow;
					column.SetCellDataFunc (cell, new TreeCellDataFunc ((col,cel,model,iter) => {
						var m = model.GetValue (iter, 0);
						var prop1 = m.GetType ().GetProperty (col.Title);
						var val = prop1.GetValue (m, null);
						(cel as CellRendererText).Text = val == null ? "" : val.ToString ();

					}));
					tvwDatos.AppendColumn (column);
				}
			}
		}



		void HandleSelectCursorRow (object o, SelectCursorRowArgs args)
		{
			
		}
	}
}


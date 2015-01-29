using System;
using Gtk;
using Actividad01.Data;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.btnClick.Clicked += this.btClick_CLicked;

	}

	protected void btClick_CLicked(object sender, EventArgs e){
		var v = new Vuelo(){
			Id = DateTime.Now.Second
		};
		Console.WriteLine (v);

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

	}
}

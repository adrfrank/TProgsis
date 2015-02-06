using Actividad01.UI.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Actividad01.UI
{
    /// <summary>
    /// Interaction logic for PasajerosWindow.xaml
    /// </summary>
    public partial class PasajerosWindow : Window
    {

        [Dependency]
        public PasajerosViewModel ViewModel
        {
            set { DataContext = value; }
        }
        public PasajerosWindow()
        {
            InitializeComponent();
        }

        // Disclaimer, untested! 
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
           
        }
    }
}

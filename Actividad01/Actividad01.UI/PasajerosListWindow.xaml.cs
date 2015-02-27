using Actividad01.UI.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PasajerosListWindow.xaml
    /// </summary>
    public partial class PasajerosListWindow : Window
    {
        public PasajerosDataViewModel ViewModel
        {
            set { DataContext = value; }
        }
        public PasajerosListWindow()
        {
            InitializeComponent();
        }
    }
}

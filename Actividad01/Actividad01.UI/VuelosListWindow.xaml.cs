using Actividad01.UI.ViewModels;
using Microsoft.Practices.Unity;
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
    /// Interaction logic for VuelosListWindow.xaml
    /// </summary>
    public partial class VuelosListWindow : Window
    {

        
        public VuelosDataViewModel ViewModel
        {
            set { DataContext = value; }
        }
        public VuelosListWindow()
        {
            InitializeComponent();
        }
    }
}

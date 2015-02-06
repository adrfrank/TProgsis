using Actividad01.Data;
using Actividad01.Data.Entities;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VuelosWindow vuelosWindow { get; set; }
        PasajerosWindow pasajerosWindow { get; set; }

    
        public MainWindow()
        {
            InitializeComponent();
            //dependency injection
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRepository<Vuelo>, FileRepository<Vuelo>>();
            container.RegisterType<IRepository<Pasajero>, FileRepository<Pasajero>>();
            vuelosWindow = container.Resolve<VuelosWindow>();
            pasajerosWindow = container.Resolve<PasajerosWindow>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vuelosWindow.Show();
        }

        private void PasajerosButton_Click(object sender, RoutedEventArgs e)
        {
            pasajerosWindow.Show();
        }
    }
}

﻿using Actividad01.Data;
using Actividad01.Data.Entities;
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
    /// Interaction logic for VuelosWindow.xaml
    /// </summary>
    public partial class VuelosWindow : Window
    {
        [Dependency]
        public VuelosViewModel ViewModel {
            set { DataContext = value; }
        }

        //VuelosEditWindow editWindow;
        public VuelosWindow()
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

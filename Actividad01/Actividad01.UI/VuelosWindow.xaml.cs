﻿using System;
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
        static VuelosWindow instance = null;
        public static VuelosWindow Instance {
            get {
                if (instance == null)
                    instance = new VuelosWindow();
                return instance;
            }
        }

        VuelosEditWindow editWindow;


        VuelosWindow()
        {
            InitializeComponent();
            editWindow = new VuelosEditWindow();
        }

        void loadItems() { 
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            editWindow.ShowCreate();
        }

        // Disclaimer, untested! 
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }
    }
}

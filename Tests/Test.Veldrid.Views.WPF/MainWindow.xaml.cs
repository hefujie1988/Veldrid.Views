﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Test.Veldrid.Views.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Grid0.SizeChanged += Grid0_SizeChanged;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // IMPORTANT
            d3D11Image.WindowOwner = (new System.Windows.Interop.WindowInteropHelper(this)).Handle;
            d3D11Image.RequestRender();
        }

        private void Grid0_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() => updateSize());
        }

        void updateSize()
        {
            // adapting the d3D11Image size to the host grid cell one
            double _w = Grid0.ColumnDefinitions[0].ActualWidth;
            double _h = Grid0.RowDefinitions[0].ActualHeight;
            d3D11Image.SetPixelSize((int)_w, (int)_h); // RequestRender is useless
        }

        private void BnTest_Click(object sender, RoutedEventArgs e)
        {
            // explicitly triggering a repaint of the d3D11Image control 
            d3D11Image.RequestRender();
        }
    }
}

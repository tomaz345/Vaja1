﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DruštvoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Vnos a = new Vnos();                     
            a.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Pregled a = new Pregled();
            a.Show();

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Zasciti z = new Zasciti();
            z.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Obnovi o = new Obnovi();
            o.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Tiskanje t = new Tiskanje();
            t.Show();
        }
    }
}

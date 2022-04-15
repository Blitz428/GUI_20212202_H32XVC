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

namespace GUItar_HerOE
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" - The point of the game is to score as many points as possible during a song.\n" +
                " - Once we have reached the right score we can advance to the next level.\n" +
                " - During the game there are circles in 4 columns that have to be pressed at the given place, then the point is awarded for it, if you press the button in the wrong place, a point is deducted.\n" +
                "   The GUItarHerOE team wishes you a good game!", 
                "Help", MessageBoxButton.OK, MessageBoxImage.None);

        }
    }
}

﻿using GUItar_HerOE.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GUItar_HerOE
{
    /// <summary>
    /// Interaction logic for Levels.xaml
    /// </summary>
    public partial class Levels : Window
    {
        // back button: <Button Content="Back" Click="Button_Click"></Button>
        // ResizeMode="NoResize"

        public Levels()
        {
            InitializeComponent();
            List<Level> levels = new List<Level>();      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                Button button = new Button();
                button.Tag = "button_" + i;
                button.Margin = new Thickness(10);
                button.Padding = new Thickness(10);
                button.Background = Brushes.LightBlue;
                button.Width = (this.ActualWidth / 3)-20;
                button.Height = (this.ActualHeight / 4.8)-20;
                button.Content =  (i+1) +". level";
                levelsWrap.Children.Add(button);
            }

            Button button_menu = new Button();
            button_menu.Tag = "button_menu";
            button_menu.Padding = new Thickness(10);
            button_menu.Margin = new Thickness(10);
            button_menu.Background = Brushes.LightBlue;
            button_menu.Width = (this.ActualWidth / 3)-20;
            button_menu.Height = (this.ActualHeight / 4.8)-20;
            button_menu.Content = "Menu";
            button_menu.Click += Button_Click;
            levelsWrap.Children.Add(button_menu);

        }
    }
}

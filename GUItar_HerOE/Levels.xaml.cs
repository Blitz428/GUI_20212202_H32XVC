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
                //button.IsEnabled = false;
                button.Tag = "button_" + i;
                button.Margin = new Thickness(10);
                button.Padding = new Thickness(10);
                button.Width = (this.ActualWidth / 3)-20;
                button.Height = (this.ActualHeight / 4.8)-20;
                button.Content = "Level "+(i+1) +".";
                button.Background = new SolidColorBrush(Color.FromArgb(70, 205, 20, 202));
                button.Foreground = new SolidColorBrush(Color.FromRgb(247, 236, 83));
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(247, 236, 83));
                button.FontWeight = FontWeights.Bold;
                button.FontSize = 20;
                button.FontFamily = new FontFamily("Consolas");
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
            button_menu.Foreground = new SolidColorBrush(Color.FromRgb(205, 130, 202));
            button_menu.Background = new SolidColorBrush(Color.FromArgb(70,247, 236, 83));
            button_menu.BorderBrush = new SolidColorBrush(Color.FromRgb(205, 130, 202));
            button_menu.FontWeight = FontWeights.Bold;
            button_menu.FontSize = 20;
            button_menu.FontFamily = new FontFamily("Consolas");
            levelsWrap.Children.Add(button_menu);

        }
    }
}

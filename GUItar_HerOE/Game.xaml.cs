using GUItar_HerOE.ViewModels;
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
using System.Windows.Threading;

namespace GUItar_HerOE
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private Random r;
        public Game()
        {
            InitializeComponent();
            r = new Random();
            GreenController.Setup("green", (double)r.Next(1, 20) / 1000);
            OrangeController.Setup("orange", (double)r.Next(1, 20) / 1000);
            YellowController.Setup("yellow", (double)r.Next(1, 20) / 1000);
            RedController.Setup("red", (double)r.Next(1, 20) / 1000);
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (DataContext as GameWindowViewModel).Closing(9);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // green
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // orange
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // yellow
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // red
        }
    }
}

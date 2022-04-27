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
        public Game()
        {
            InitializeComponent();
            TimersCreateAndSet(5, 10, 8, 20,600);
        }

        private void TimersCreateAndSet(double green, double orange, double red, double yellow, double speed)
        {
            //DispatcherTimer dispatcherTimer_green = new DispatcherTimer(DispatcherPriority.Send);
            //dispatcherTimer_green.Interval = TimeSpan.FromSeconds(green / speed);
            //dispatcherTimer_green.Tick += DispatcherTimer_green_Tick;
            //dispatcherTimer_green.Start();

            //DispatcherTimer dispatcherTimer_orange = new DispatcherTimer(DispatcherPriority.Send);
            DispatcherTimer dispatcherTimer_orange = new DispatcherTimer();
            dispatcherTimer_orange.Interval = TimeSpan.FromSeconds(orange / speed);
            dispatcherTimer_orange.Tick += DispatcherTimer_orange_Tick;
            dispatcherTimer_orange.Start();

            DispatcherTimer dispatcherTimer_red = new DispatcherTimer();
            dispatcherTimer_red.Interval = TimeSpan.FromSeconds(red / speed);
            dispatcherTimer_red.Tick += DispatcherTimer_red_Tick;
            dispatcherTimer_red.Start();

            DispatcherTimer dispatcherTimer_yellow = new DispatcherTimer();
            dispatcherTimer_yellow.Interval = TimeSpan.FromSeconds(yellow / speed);
            dispatcherTimer_yellow.Tick += DispatcherTimer_yellow_Tick;
            dispatcherTimer_yellow.Start();
        }

        private void DispatcherTimer_yellow_Tick(object sender, EventArgs e)
        {
            //YellowColumnRenderer.InvalidateVisual();
        }

        private void DispatcherTimer_red_Tick(object sender, EventArgs e)
        {
            //RedColumnRenderer.InvalidateVisual();
        }

        private void DispatcherTimer_orange_Tick(object sender, EventArgs e)
        {
            //OrangeColumnRenderer.InvalidateVisual();
        }

        //private void DispatcherTimer_green_Tick(object sender, EventArgs e)
        //{
        //    //GreenColumnRenderer.InvalidateVisual();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (DataContext as GameWindowViewModel).Closing(9);
        }
    }
}

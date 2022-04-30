using GUItar_HerOE.Logic;
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
        private int MusicID;
        private Random r;
        private MusicLogic musicLogic;
        DispatcherTimer mainTimer;
        public int points = 0;

        public Game(int MusicID)
        {
            InitializeComponent();
            r = new Random();
            musicLogic = new MusicLogic();
            musicLogic.StartMusic(MusicID);
            MusicName.Content = musicLogic.CurrentMusicName();
            this.MusicID = MusicID;
            GreenController.Setup("green", (double)r.Next(1, 20) / 1000);
            OrangeController.Setup("orange", (double)r.Next(1, 20) / 1000);
            YellowController.Setup("yellow", (double)r.Next(1, 20) / 1000);
            RedController.Setup("red", (double)r.Next(1, 20) / 1000);
            
            mainTimer = new DispatcherTimer(DispatcherPriority.Send);
            mainTimer.Interval = TimeSpan.FromSeconds(0.001);
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            points = 0;
            points += GreenController.gameModel.Point;
            points += OrangeController.gameModel.Point;
            points += YellowController.gameModel.Point;
            points += RedController.gameModel.Point;
            point.Content = points;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            musicLogic.StopMusic(MusicID);
            musicLogic.StartMusic(8);
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

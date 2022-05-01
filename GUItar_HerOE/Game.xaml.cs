using GUItar_HerOE.Logic;
using GUItar_HerOE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        DispatcherTimer soundTimer;
        private int songLenght;
        public int points = 0;
        int m=1, s=20;

        public Game(int MusicID)
        {
            InitializeComponent();
            r = new Random();
            musicLogic = new MusicLogic();
            musicLogic.StartMusic(MusicID);
            songLenght = musicLogic.CurrentMusicLenght();
            
            soundTimer = new DispatcherTimer(DispatcherPriority.Send);
            soundTimer.Interval = TimeSpan.FromSeconds(1);
            soundTimer.Tick += SoundTimer_Tick;
            soundTimer.Start();

            timer.Content = $"{0}:{m}:{s}";
            MusicName.Content = musicLogic.CurrentMusicName();
            levels.Content = MusicID+1;
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

        private void SoundTimer_Tick(object sender, EventArgs e)
        {
            s -= 1;
            if (s == 0 && m == 0)
            {
                soundTimer.Stop();
                mainTimer.Stop();
                musicLogic.StopMusic(MusicID);
                new GameEnd(points, "msg").ShowDialog();
                this.Close();
            }

            if (s == 0)
            {
                s = 59;
                m -= 1;
            }

            timer.Content = $"{0}:{m}:{s}";
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

        private void Close(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }

        private void Game_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            musicLogic.StopMusic(MusicID);
            musicLogic.StartMusic(8);
            MainWindow mainWindow = new MainWindow();
            mainWindow.CustomMusicDelete(sender, e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    GreenColumnAction();
                    break;
                case Key.Up:
                    OrangeColumnAction();
                    break;
                case Key.Down:
                    YellowColumnAction();
                    break;
                case Key.Right:
                    RedColumnAction();
                    break;
                default:
                    break;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label && (e.Source as Label).Name != null)
            {
                switch ((e.Source as Label).Name)
                {
                    case "GreenArrow":
                        GreenColumnAction();
                        break;
                    case "OrangeArrow":
                        OrangeColumnAction();
                        break;
                    case "YellowArrow":
                        YellowColumnAction();
                        break;
                    case "RedArrow":
                        RedColumnAction();
                        break;
                    default:
                        break;
                }
            }
        }

        private void GreenColumnAction()
        {
        }

        private void OrangeColumnAction()
        {
        }

        private void YellowColumnAction()
        {
        }

        private void RedColumnAction()
        {
        }
    }
}

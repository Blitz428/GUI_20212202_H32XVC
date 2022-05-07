using GUItar_HerOE.Logic;
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

namespace GUItar_HerOE
{
    /// <summary>
    /// Interaction logic for GameEnd.xaml
    /// </summary>
    public partial class GameEnd : Window
    {
        //private MusicLogic musicLogic;
        //private MediaElement mediaElement;
        public GameEnd(int point, string msg)
        {
            InitializeComponent();
            //musicLogic = new MusicLogic();
            //mediaElement = new MediaElement();
            lb_point.Content = point;
            lb_msg.Content = msg;
            //if (msg== "Nem a játék a nehéz, Te vagy béna!")
            //{
            //    mediaElement.Source = new Uri(musicLogic.musicPlayer.songFolderPath + "lose.wav");
                
            //}
            //else
            //{
            //    mediaElement.Source = new Uri(musicLogic.musicPlayer.songFolderPath + "win.wav");
            //}
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}

using GUItar_HerOE.Models;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUItar_HerOE.Logic
{
    public class GameLogic : IGameLogic
    {
        private MusicLogic musicLogic;
        private GameModel gameModel;
        private IMenuLogic menuLogic;
        private IMessenger messenger;

        public int Point { get; set; }
        public string CurrentSong { get; set; }

        public GameLogic(GameModel gameModel)
        {
            this.gameModel = gameModel;
            musicLogic = new MusicLogic();
        }

        public GameLogic(IMenuLogic menuLogic, IMessenger messenger)
        {
            this.messenger = messenger;
            this.menuLogic = menuLogic;
            musicLogic = new MusicLogic();
        }

        public void MusicStart(int id)
        {
            musicLogic.StartMusic(id);
            CurrentSong = musicLogic.CurrentMusicName();
            Point = 0;
            messenger.Send("Song and point values changed!", "GameInfo");
        }

        public void MusicStop(int id)
        {
            musicLogic.StopMusic(id);
        }

        public void Closing(int id)
        {
            MusicStop(id);
            menuLogic.CustomMusicDelete();
            menuLogic.MenuMusicStart();
        }

        public void Opening(int musicId)
        {
            MusicStart(musicId);
        }

        public void GuitarTick(Guitar guitar)
        {
            guitar.Procent += 1;
            if (guitar.Procent > 350)
            {
                guitar.Procent = 0;
                guitar.Activated = false;
            }
        }

        public void OneTick()
        {
            foreach (Guitar guitar in gameModel.Guitars)
            {
                GuitarTick(guitar);
            }
        }

        public void CheckGuitar(string color)
        {
            //foreach (Guitar guitar in gameModel.Guitars)
            //{
            //    if ((guitar.Procent > 293 && 350 > guitar.Procent))
            //    {
            //        // ezen időszakban kell aktiválni
            //        guitar.Activated = true;
            //    }
            //    if (guitar.Procent > 349 && !guitar.Activated)
            //    {
            //        // itt kell vizsgálni, hogy lenyomta e
            //        Point -= 10;
            //        messenger.Send("ponits changed!", "GameInfo");
            //        //MessageBox.Show($"-10 Color:{guitar.Color}");
            //        //messenger.Send("Point changed!", "GameInfo");
            //    }
            //}
        }

        public void GuitarContact_green()
        {
            CheckGuitar("green");
        }

        public void GuitarContact_red()
        {
            CheckGuitar("red");
        }

        public void GuitarContact_yellow()
        {
            CheckGuitar("yellow");
        }

        public void GuitarContact_orange()
        {
            CheckGuitar("orange");
        }

    }
}

using GUItar_HerOE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public class GameLogic : IGameLogic
    {
        private MusicPlayer musicPlayer;
        private IMenuLogic menuLogic;
        private GameModel gameModel;

        public GameLogic(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public GameLogic(IMenuLogic menuLogic)
        {
            this.menuLogic = menuLogic;
        }

        public void MusicStart(int id)
        {
            musicPlayer = new MusicPlayer();
            musicPlayer.SelectSong(id);
            musicPlayer.Play();
        }

        public void MusicStop(int id)
        {
            musicPlayer = new MusicPlayer();
            musicPlayer.SelectSong(id);
            musicPlayer.Stop();
        }

        public void Closing(int id)
        {
            MusicStop(id);
            menuLogic.CustomMusicDelete();
            menuLogic.MenuMusicStart();     
        }

        public void GuitarTick(Guitar guitar)
        {
            guitar.Procent += 1;
            if (guitar.Procent > 372)
            {
                guitar.Procent = 0;
            }
        }

        public void OneTick()
        {
            foreach (Guitar guitar in gameModel.Guitars)
            {
                GuitarTick(guitar);
            }
        }

    }
}

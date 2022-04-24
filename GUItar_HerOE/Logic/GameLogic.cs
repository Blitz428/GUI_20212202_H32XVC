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
    }
}

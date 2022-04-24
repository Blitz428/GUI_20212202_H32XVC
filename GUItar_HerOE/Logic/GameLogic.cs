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

        public void MusicStart(int id)
        {
            musicPlayer = new MusicPlayer();
            musicPlayer.SelectSong(id);
            musicPlayer.Play();
        }
    }
}

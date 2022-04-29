using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public interface IGameLogic
    {
        public int Point { get; set; }
        public string CurrentSong { get; set; }
        public void MusicStart(int id);
        public void MusicStop(int id);
        public void Closing(int id);
        public void GuitarContact_green();
        public void GuitarContact_red();
        public void GuitarContact_yellow();
        public void GuitarContact_orange();
        public void Opening(int musicId);
    }
}

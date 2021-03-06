using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public interface IMenuLogic
    {
        public bool isUnlock { get; set; }
        public void OpenLevelsWindow();
        public void OpenGameWindow(int MusicID);
        public void CustomMusicLoading();
        public void CustomMusicDelete();
        public bool UnlockLevels();
        public void MenuMusicStart();
    }
}

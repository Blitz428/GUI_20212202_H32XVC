using GUItar_HerOE.Service;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUItar_HerOE.Logic
{
    public class MenuLogic : IMenuLogic
    {
        private IOpenGameWindowService openGameWindow;
        private IOpenLevelsWindowService openLevelsWindowService;
        private IMessenger messenger;
        private MusicLogic musicLogic;
        private string cusctomMusicName { get; set; }
        public bool isUnlock { get; set; }

        public MenuLogic(IMessenger messenger, IOpenGameWindowService openGameWindow, IOpenLevelsWindowService openLevelsWindowService)
        {
            isUnlock = false;
            this.messenger = messenger;
            this.openGameWindow = openGameWindow;
            this.openLevelsWindowService = openLevelsWindowService;
            musicLogic = new MusicLogic();
        }

        public void OpenLevelsWindow()
        {
            openLevelsWindowService.Open();
        }

        public void OpenGameWindow(int MusicID)
        {
            openGameWindow.Open(MusicID);
        }

        public void OpenCustomGameWindow(int MusicID)
        {
            openGameWindow.Open(MusicID);
        }

        public void CustomMusicLoading()
        {
            musicLogic.CustomMusicLoading();
            OpenCustomGameWindow(9);
        }

        public void CustomMusicDelete()
        {
            musicLogic.CustomMusicDelete();
        }

        public bool UnlockLevels()
        {
            isUnlock = !isUnlock;
            messenger.Send("Unlock changed!", "MenuInfo");
            return isUnlock;
        }

        public void MenuMusicStart()
        {
            musicLogic.CustomMusicDelete();
            musicLogic.StartMusic(8);
        }
    }
}

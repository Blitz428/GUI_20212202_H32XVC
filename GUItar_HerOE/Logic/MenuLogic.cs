using GUItar_HerOE.Service;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
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
        private string songPath;
        public bool isUnlock {get; set;}

        public MenuLogic(IMessenger messenger, IOpenGameWindowService openGameWindow, IOpenLevelsWindowService openLevelsWindowService)
        {
            isUnlock = false;
            this.messenger = messenger;
            this.openGameWindow = openGameWindow;
            this.openLevelsWindowService = openLevelsWindowService;
        }

        public void OpenLevelsWindow()
        {
            openLevelsWindowService.Open();
        }

        public void OpenGameWindow()
        {
            openGameWindow.Open();
        }

        public void OpenFileBrowser()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                songPath = folderBrowserDialog.SelectedPath;
            }
        }

        public bool UnlockLevels()
        {
            isUnlock = !isUnlock;
            messenger.Send("Unlock changed!", "MenuInfo");
            return isUnlock;
        }
    }
}

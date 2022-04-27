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
        private string cusctomMusicName;
        public bool isUnlock {get; set;}
        private MusicPlayer musicPlayer;

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
            musicPlayer.Stop();
            musicPlayer.SelectSong(1);
            musicPlayer.Play();
            openGameWindow.Open();
        }

        public void OpenCustomGameWindow()
        {
            musicPlayer.Stop();
            musicPlayer.SelectSong(9);
            musicPlayer.Play();
            openGameWindow.Open();
        }

        public void CustomMusicLoading()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var splittedSongPath = openFileDialog.FileName.Split("\\");
                cusctomMusicName = splittedSongPath[splittedSongPath.Length - 1];
              
                string sourcePath = openFileDialog.FileName;
                string targetPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Songs");

                string destFile = System.IO.Path.Combine(targetPath, "z_"+ cusctomMusicName);

                System.IO.File.Copy(sourcePath, destFile, true);
            }
            OpenCustomGameWindow();
        }

        public void CustomMusicDelete()
        {
            string deletePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"GUItar_HerOE\\Songs\\z_{cusctomMusicName}");

            if (deletePath != null)
            {
                System.IO.File.Delete(deletePath);
            }
        }
    
        public bool UnlockLevels()
        {
            isUnlock = !isUnlock;
            messenger.Send("Unlock changed!", "MenuInfo");
            return isUnlock;
        }

        public void MenuMusicStart()
        {
            musicPlayer = new MusicPlayer();
            musicPlayer.SelectSong(8);
            musicPlayer.Play();
        }
    }
}

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
    class MusicLogic : IMusicLogic
    {
        public MusicPlayer musicPlayer;
        private string currentMusicName;
        private string currentCustomMusicName;
        private int currentMusicLenght;

        public MusicLogic()
        {
            musicPlayer = new MusicPlayer();
        }

        public void StartMusic(int id)
        {
            musicPlayer.SelectSong(id);
            musicPlayer.Play();
            currentMusicLenght = musicPlayer.SongTimeLenght();
            currentMusicName = musicPlayer.CurrentSong;
            if (currentMusicName != null)
            {
                currentMusicName = (currentMusicName.Split('.')[0]).Split('_')[1];
            }
           
        }

        public void StopMusic(int id)
        {
            musicPlayer.SelectSong(id);
            musicPlayer.Stop();
        }

        public string CurrentMusicName()
        {
            return currentMusicName;
        }

        public string CurrentCusctomMusicName()
        {
            return currentCustomMusicName;
        }

        public int CurrentMusicLenght()
        {
            return currentMusicLenght;
        }

        public void CustomMusicDelete()
        {
            string deletePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"GUItar_HerOE\\Songs\\z_{currentCustomMusicName}");

            if (deletePath != null && currentCustomMusicName != null)
            {
                System.IO.File.Delete(deletePath);

            }
        }

        public bool CustomMusicLoading()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                     
                string sourcePath = openFileDialog.FileName;
                string targetPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Songs");

                var splittedSongPath = openFileDialog.FileName.Split("\\");
                currentMusicName = splittedSongPath[splittedSongPath.Length - 1];
                currentCustomMusicName = splittedSongPath[splittedSongPath.Length - 1];

                string destFile = System.IO.Path.Combine(targetPath, "z_" + currentMusicName);

                System.IO.File.Copy(sourcePath, destFile, true);             
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

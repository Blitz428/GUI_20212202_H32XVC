using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public class MusicPlayer
    {
        private SoundPlayer soundPlayer;
        private List<string> songs;
        public string songFolderPath;
        public string CurrentSong;

        public MusicPlayer()
        {
            songs = new List<string>();
            songFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Songs\");
            var files = Directory.GetFiles(songFolderPath);

            foreach (var current_file in files)
            {
                if (current_file.ToString().Contains(".wav"))
                {
                    songs.Add(current_file.Split(songFolderPath)[1]);
                }
            }
        }

        public void UpdateList()
        {
            var files = Directory.GetFiles(songFolderPath);
            songs = new List<string>();
            foreach (var current_file in files)
            {
                if (current_file.ToString().Contains(".wav"))
                {
                    if (!songs.Contains(current_file.Split(songFolderPath)[1]))
                    {
                        songs.Add(current_file.Split(songFolderPath)[1]);
                    }
                }
            }
        }

        public void SelectSong(int id)
        {
            UpdateList();
            if (songs.Count() > id && id >= 0)
            {
                soundPlayer = new System.Media.SoundPlayer($"{songFolderPath}{songs[id]}");
                CurrentSong = songs[id];
            }
        }

        public void Play()
        {
            if (soundPlayer != null)
            {
                soundPlayer.Play();
            }
        }

        public void Stop()
        {
            if (soundPlayer != null)
            {
                soundPlayer.Stop();
            }
        }

        public int SongTimeLenght()
        {
            if (soundPlayer != null)
            {
                return soundPlayer.LoadTimeout;
            }
            return 0;
        }
    }
}

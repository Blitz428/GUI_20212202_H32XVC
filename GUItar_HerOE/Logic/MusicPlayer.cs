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

        public MusicPlayer()
        {
            songs = new List<string>();
            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Songs\");
            var files = Directory.GetFiles(startupPath);
            
            foreach (var file in files)
            {
                if (file.ToString().Contains(".wav"))
                {
                    songs.Add(file.Split(startupPath)[1]);
                }
            }
        }

        public void SelectSong(int id)
        {
            if (songs.Count() > id && id >= 0)
            {
                soundPlayer = new System.Media.SoundPlayer(Assembly.LoadFrom("GUItar_HerOE").GetManifestResourceStream($"GUItar_HerOE.Songs.{songs[id]}"));
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
    }
}

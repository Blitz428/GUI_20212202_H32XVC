using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public class ImageLoader
    {
        public List<string> images;
        public string imageFolderPath;

        public ImageLoader()
        {
            images = new List<string>();
            imageFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\SongCovers\");
            var files = Directory.GetFiles(imageFolderPath);

            foreach (var current_file in files)
            {
                if (current_file.ToString().Contains(".jpg"))
                {
                    images.Add(current_file.Split(imageFolderPath)[1]);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUItar_HerOE.Renderer
{
    abstract class Display : FrameworkElement
    {
        protected string imagePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Images\GameImage");

        public Brush GuitarBrush_green
        {
            get
            {               
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(imagePath,"green.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush GuitarBrush_orange
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(imagePath, "orange.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush GuitarBrush_red
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(imagePath, "red.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush GuitarBrush_yellow
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(imagePath, "yellow.png"), UriKind.RelativeOrAbsolute)));
            }
        }
    }
}

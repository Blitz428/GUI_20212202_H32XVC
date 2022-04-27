using GUItar_HerOE.Models;
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
    public class GameRenderer_green
    {
        private GameModel model;
        protected string imagePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Images\GameImage");

        public Brush GuitarBrush_green
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(imagePath, "green.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public GameRenderer_green(GameModel model)
        {
            this.model = model;
        }

        public void BuildDisplay(DrawingContext drawingContext)
        {
            foreach (Guitar guitar in model.Guitars)
            {
                drawingContext.DrawRectangle(GuitarBrush_green, null, new Rect(20, guitar.Procent, 40, 40));
            }
        }
    }
}

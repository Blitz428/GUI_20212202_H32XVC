using GUItar_HerOE.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUItar_HerOE.Renderer
{
    class GameRenderer
    {
        private GameModel model;
        private Typeface fontStyle = new Typeface("Consolas");
        private string color;
        private string imagePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"GUItar_HerOE\Images\GameImage");

        public GameRenderer(string color, GameModel model)
        {           
            this.color = color;
            this.model = model;
        }

        public Brush GuitarBrush_green
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(imagePath, $"{color}.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public void BuildDisplay(DrawingContext drawingContext)
        {
            foreach (Guitar guitar in model.Guitars)
            {
                drawingContext.DrawRectangle(GuitarBrush_green, null, new Rect(20, guitar.Procent, 40, 40));
            }
        }

        public void DraWText(DrawingContext drawingContext)
        {
            FormattedText formattedText = new FormattedText(
                model.Point.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                fontStyle,
                20,
                Brushes.White
                );
            drawingContext.DrawText(formattedText, new Point(10, 10));
        }
    }
}

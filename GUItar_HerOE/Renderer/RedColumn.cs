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
    class RedColumn : Display
    {
        private double Counter = 0;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawRectangle(GuitarBrush_red, null, new Rect(20, Counter += 0.2, 40, 40));
        }
    }
}

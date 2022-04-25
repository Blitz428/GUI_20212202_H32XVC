using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUItar_HerOE.Renderer
{
    class GreenColumn : Display
    {
        private double Counter = 0;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);           
            drawingContext.DrawRectangle(GuitarBrush_green, null, new Rect(20, Counter += 0.2, 40, 40));             
              
        }
    }
}

using GUItar_HerOE.Logic;
using GUItar_HerOE.Models;
using GUItar_HerOE.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUItar_HerOE.Controller
{
    public class GameController_yellow : FrameworkElement
    {            
        GameLogic gameLogic;
        GameModel gameModel;
        GameRenderer_yellow gameRenderer;
        DispatcherTimer mainTimer;

        public GameController_yellow()
        {
            Loaded += GameControl_Loaded;
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            gameModel = new GameModel(0, 20);
            gameLogic = new GameLogic(gameModel);        
            gameRenderer = new GameRenderer_yellow(gameModel);

            foreach (var guitar in gameModel.Guitars)
            {
                guitar.Color = "yellow";
                guitar.Activated = false;
            }

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                mainTimer = new DispatcherTimer(DispatcherPriority.Send);
                mainTimer.Interval = TimeSpan.FromSeconds(0.02);
                mainTimer.Tick += MainTimer_Tick;
                mainTimer.Start();
            }

            InvalidateVisual();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            gameLogic.OneTick();
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameRenderer != null)
            {
                gameRenderer.BuildDisplay(drawingContext);
            }
        }
    }
}

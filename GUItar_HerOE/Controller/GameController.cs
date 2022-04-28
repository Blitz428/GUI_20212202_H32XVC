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
    public class GameController : FrameworkElement
    {
        GameLogic gameLogic;
        GameModel gameModel;
        GameRenderer gameRenderer;
        DispatcherTimer mainTimer;
        private string color;
        private double timer;

        public void Setup(string color, double timer)
        {
            this.color = color;
            this.timer = timer;
        }       

        public GameController()
        {
            Loaded += GameControl_Loaded;
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            gameModel = new GameModel(0, 20);
            gameRenderer = new GameRenderer(color, gameModel);
            gameLogic = new GameLogic(gameModel);

            foreach (var guitar in gameModel.Guitars)
            {
                guitar.Color = color;
                guitar.Activated = false;
            }

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                mainTimer = new DispatcherTimer(DispatcherPriority.Send);
                mainTimer.Interval = TimeSpan.FromSeconds(timer);
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

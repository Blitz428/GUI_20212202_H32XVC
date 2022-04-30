using GUItar_HerOE.Logic;
using GUItar_HerOE.Models;
using GUItar_HerOE.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUItar_HerOE.Controller
{
    public class GameController : FrameworkElement
    {
        public GameModel gameModel;

        private GameLogic gameLogic;
        private GameRenderer gameRenderer;
        private DispatcherTimer mainTimer;
        private string color;
        private double timer;

        public GameController()
        {
            Loaded += GameControl_Loaded;           
        }

        public void Setup(string color, double timer)
        {
            this.color = color;
            this.timer = timer;
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
                win.KeyDown += this.Win_KeyDown;
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

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    gameLogic.CheckGuitar("green");
                    break;
                case Key.Up:
                    gameLogic.CheckGuitar("orange");
                    break;
                case Key.Down:
                    gameLogic.CheckGuitar("yellow");
                    break;
                case Key.Right:
                    gameLogic.CheckGuitar("red");
                    break;
                default:
                    break;


            }
           this.InvalidateVisual();            
        }
    }
}

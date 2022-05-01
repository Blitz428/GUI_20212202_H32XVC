using GUItar_HerOE.Models;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUItar_HerOE.Logic
{
    public class GameLogic : IGameLogic
    {
        private MusicLogic musicLogic;
        private GameModel gameModel;
        private Random random;

        public int Point { get; set; }
        public string CurrentSong { get; set; }

        public GameLogic(GameModel gameModel)
        {
            this.gameModel = gameModel;
            musicLogic = new MusicLogic();
            random = new Random();
        }

        public void GuitarTick(Guitar guitar)
        {
            guitar.Procent += 1;
            if (guitar.Procent > 350)
            {
                gameModel.Point -= 10;
                gameModel.MaxPoint += 10;
                guitar.Procent = random.Next(0, 30);
            }
        }

        public void OneTick()
        {
            foreach (Guitar guitar in gameModel.Guitars)
            {
                GuitarTick(guitar);
            }
        }

        public void CheckGuitar(string color)
        {
            List<Guitar> check_guitars = new List<Guitar>();
            foreach (Guitar guitar in gameModel.Guitars)
            {
                if (guitar.Color == color)
                {
                    check_guitars.Add(guitar);
                }
            }

            if (check_guitars.Count() != 0)
            {
                gameModel.MaxPoint += 10;
                Guitar maxGuitar = check_guitars.OrderBy(x => x.Procent).Last();
                Guitar guitar1 = gameModel.Guitars.Find(x => x == maxGuitar);

                if (maxGuitar.Procent > 293 && 350 > maxGuitar.Procent)
                {
                    guitar1.Procent = 0;
                    gameModel.Point += 10;
                }
                else
                {
                    gameModel.Point -= 10;
                }
            }
        }
    }
}

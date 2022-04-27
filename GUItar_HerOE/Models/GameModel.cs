using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Models
{
    public class GameModel
    {
        public const int Xstep = 100;
        const int NumGuitar = 4;
        public static Random random;

        public List<Guitar> Guitars { get; private set; }
        public double GameWidht { get; private set; }
        public double GameHeight { get; private set; }

        public GameModel(double widht, double height)
        {
            this.GameHeight = height;
            this.GameWidht = widht;
            Guitars = new List<Guitar>();
            random = new Random();
            
            for (int i = 0; i <= NumGuitar+1; i++)
            {
                Guitars.Add(new Guitar((i * GameHeight / NumGuitar)*random.Next(15,40)));
            }
            ;
        }
    }
}

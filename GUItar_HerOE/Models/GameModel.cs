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
        const int NumGuitar = 3;
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
            
            for (int i = 1; i <= NumGuitar; i++)
            {
                Guitars.Add(new Guitar((i * (350 / random.Next(2,4)))+10 / NumGuitar )); //* random.Next(25,40)
            }
        }
    }
}

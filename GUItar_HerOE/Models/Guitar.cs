using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Models
{
    public class Guitar
    {
        public double Procent { get; set; }
        public bool Activated { get; set; }
        public string Color { get; set; }

        public Guitar(double procent)
        {
            Procent = procent;
        }
    }
}

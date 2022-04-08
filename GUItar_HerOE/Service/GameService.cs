using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Service
{
    public class GameService : IOpenWindowService
    {
        public void Open()
        {
            new Game().ShowDialog();
        }
    }
}

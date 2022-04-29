using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Service
{
    public class OpenGameWindowService : IOpenGameWindowService
    {
        public void Open(int MusicID)
        {
            new Game(MusicID).ShowDialog();
        }
    }
}

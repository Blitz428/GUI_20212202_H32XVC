using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Service
{
    public class OpenLevelsWindowService : IOpenLevelsWindowService
    {
        public void Open()
        {
            new Levels().ShowDialog();
        }
    }
}

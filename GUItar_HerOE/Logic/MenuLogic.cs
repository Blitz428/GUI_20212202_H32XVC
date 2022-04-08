using GUItar_HerOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUItar_HerOE.Logic
{
    public class MenuLogic : IMenuLogic
    {
        private IOpenWindowService openWindowService;

        public MenuLogic(IOpenWindowService openWindowService)
        {
            this.openWindowService = openWindowService;
        }

        public void OpenLevelsWindow()
        {
            (openWindowService as LevelsService).Open();
        }

        public void OpenGameWindow()
        {
            (openWindowService as GameService).Open();
        }
 
    }
}

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
        private IOpenGameWindowService openGameWindow;
        private IOpenLevelsWindowService openLevelsWindowService;

        public MenuLogic(IOpenGameWindowService openGameWindow, IOpenLevelsWindowService openLevelsWindowService)
        {
            this.openGameWindow = openGameWindow;
            this.openLevelsWindowService = openLevelsWindowService;
        }

        public void OpenLevelsWindow()
        {
            openLevelsWindowService.Open();
        }

        public void OpenGameWindow()
        {
            openGameWindow.Open();
        }
    }
}

using GUItar_HerOE.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUItar_HerOE.ViewModels
{
    class GameWindowViewModel : ObservableRecipient
    {
        public double Point { get; set; }
        public int CurrentLevel { get; set; }
        private IGameLogic logic;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GameWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IGameLogic>())
        {

        }

        public GameWindowViewModel(IGameLogic logic)
        {
            this.logic = logic; 
        }

        public void MusicStart(int id)
        {
            logic.MusicStart(id);
        }
    }
}

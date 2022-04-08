using GUItar_HerOE.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUItar_HerOE.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand OpenLevelsWindow { get; set; }
        public ICommand OpenGameWindow { get; set; }
        private IMenuLogic logic;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IMenuLogic>())
        {

        }

        public MainWindowViewModel(IMenuLogic logic)
        {
            this.logic = logic;

            OpenLevelsWindow = new RelayCommand(
                () => logic.OpenLevelsWindow()
                );

            OpenGameWindow = new RelayCommand(
                () => logic.OpenGameWindow()
                );
        }
    }
}

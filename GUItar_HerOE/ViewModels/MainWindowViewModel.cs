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
        public ICommand CustomMusicLoading { get; set; }
        public ICommand UnlockLevels { get; set; }
        private IMenuLogic logic;
        
        private bool isUnlock;

        public bool IsUnlock
        {
            get { return isUnlock = logic.isUnlock; }
        }

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
            isUnlock = false;

            OpenLevelsWindow = new RelayCommand(
                () => logic.OpenLevelsWindow()
                );

            OpenGameWindow = new RelayCommand(
                () => logic.OpenGameWindow()
                );

            CustomMusicLoading = new RelayCommand(
               () => logic.CustomMusicLoading()
               );

            UnlockLevels = new RelayCommand(
               () => logic.UnlockLevels()
               );         

            Messenger.Register<MainWindowViewModel, string, string>(this, "MenuInfo", (recepient, msg) =>
            {
                OnPropertyChanged(nameof(isUnlock));
            });
        }

        public void MenuMusicStart()
        {
            logic.MenuMusicStart();
        }

        public void CustomMusicDelete()
        {
            logic.CustomMusicDelete();
        }
    }
}

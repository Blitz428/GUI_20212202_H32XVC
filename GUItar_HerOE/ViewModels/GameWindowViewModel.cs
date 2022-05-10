using GalaSoft.MvvmLight.Command;
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
using System.Windows.Input;

namespace GUItar_HerOE.ViewModels
{
    class GameWindowViewModel : ObservableRecipient
    {
        public int CurrentLevel { get; set; }
        public ICommand GuitarContact_green { get; set; }
        public ICommand GuitarContact_orange { get; set; }
        public ICommand GuitarContact_red { get; set; }
        public ICommand GuitarContact_yellow { get; set; }
        private IGameLogic logic;

        public int Point
        {
            get { return logic.Point; }
        }

        public string CurrentSong
        {
            get { return logic.CurrentSong; }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public GameWindowViewModel(IGameLogic logic)
        {
            this.logic = logic;

            Messenger.Register<GameWindowViewModel, string, string>(this, "GameInfo", (recepient, msg) =>
            {
                OnPropertyChanged(nameof(Point));
                OnPropertyChanged(nameof(CurrentSong));
            });
        }
    }
}

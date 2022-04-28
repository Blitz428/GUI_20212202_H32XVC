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

        public GameWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IGameLogic>())
        {

        }

        public GameWindowViewModel(IGameLogic logic)
        {
            this.logic = logic;

            GuitarContact_green = new RelayCommand(
                () => logic.GuitarContact_green()
                );

            GuitarContact_orange = new RelayCommand(
                () => logic.GuitarContact_orange()
                );

            GuitarContact_red = new RelayCommand(
                () => logic.GuitarContact_red()
                );

            GuitarContact_yellow = new RelayCommand(
                () => logic.GuitarContact_yellow()
                );

            Messenger.Register<GameWindowViewModel, string, string>(this, "GameInfo", (recepient, msg) =>
            {
                OnPropertyChanged(nameof(Point));
            });
        }

        public void MusicStart(int id)
        {
            logic.MusicStart(id);
        }

        public void MusicStop(int id)
        {
            logic.MusicStop(id);
        }

        public void Closing(int id)
        {
            logic.Closing(id);
        }
    }
}

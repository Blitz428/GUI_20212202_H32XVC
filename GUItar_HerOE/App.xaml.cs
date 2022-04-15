using GUItar_HerOE.Logic;
using GUItar_HerOE.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUItar_HerOE
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<IMenuLogic, MenuLogic>()
                .AddSingleton<IGameLogic, GameLogic>()
                .AddSingleton<IOpenGameWindowService, OpenGameWindowService>()
                .AddSingleton<IOpenLevelsWindowService, OpenLevelsWindowService>()
                .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                .BuildServiceProvider());
        }
    }
}

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MyElectricBuddy.Core.Extensions;
using MyElectricBuddy.Core.Helpers;
using MyElectricBuddy.Core.ViewModels;
using MyElectricBuddy.Core.ViewModels.Headers;
using MyElectricBuddy.Core.Views;
using MyElectricBuddy.Core.Views.Headers;
using System;

namespace MyElectricBuddy.Core;

public partial class App : Application
{
    public static IServiceProvider? Services { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        RegisterServices();

        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        DataTemplates.Add(Services!.GetRequiredService<ViewLocator>());

        base.OnFrameworkInitializationCompleted();
    }

    public override void RegisterServices()
    {
        base.RegisterServices();

        IServiceCollection serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<ViewLocator>();
        serviceCollection.AddView<MainHeaderViewModel, MainHeaderView>();

        Services = serviceCollection.BuildServiceProvider();
    }
}
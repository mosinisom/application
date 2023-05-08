using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using application.ViewModels;
using application.Views;
using Microsoft.Extensions.DependencyInjection;

namespace application;

public partial class App : Application
{
    public static IServiceProvider _services {get; set;}

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServiceProvider()
    {
        var services = ConfigureServices();
        _services = services.BuildServiceProvider();
    }
    private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        
        //services.Configure<UserServiceSettings>(builder.Configuration.GetSection("UserServiceSettings"));

        services.AddTransient<IDBQueryProxy, PostgresProxy>();
        services.AddTransient<UserService>();
        services.AddTransient<Data>();
        services.AddTransient<MainWindowViewModel>();
        return services;
    }

    public override void RegisterServices()
    {
        ConfigureServiceProvider();
        base.RegisterServices();
    }

}
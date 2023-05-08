using application.ViewModels;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace application.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App._services.GetRequiredService<MainWindowViewModel>();
    }
}
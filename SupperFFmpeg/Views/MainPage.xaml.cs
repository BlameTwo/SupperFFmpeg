using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.ViewModels;

namespace SupperFFmpeg.Views;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        this.ViewModel = AppLifeRegister.GetService<MainViewModel>();
        this.ViewModel.NavigationService.RegisterView(frameBase);
        this.ViewModel.NavigationViewService.Register(navigationView);
        Loaded += MainPage_Loaded;
    }

    private void MainPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.titlebar.Window = ViewModel.WindowManagerService.Window;
    }

    public MainViewModel ViewModel { get; }


    private void Menu_ChangedOpen(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        navigationView.IsPaneOpen = !navigationView.IsPaneOpen;
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        splitView.IsPaneOpen = !splitView.IsPaneOpen;
    }
}

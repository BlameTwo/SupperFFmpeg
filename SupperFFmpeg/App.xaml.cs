using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Views;

namespace SupperFFmpeg;

public partial class App : FFmpegApplication
{
    public App()
    {
        this.InitializeComponent();
    }

    protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        await AppLifeRegister.InitService();
        Window win = new();
        if(win.Content == null)
        {
            win.Content = AppLifeRegister.GetService<MainPage>();
            win.SystemBackdrop = new MicaBackdrop();
        }
        var winservice = AppLifeRegister.GetService<IWindowManagerService>();
        winservice.Window = win;
        win.Activate();
        this.MainWindow = win;
    }
}

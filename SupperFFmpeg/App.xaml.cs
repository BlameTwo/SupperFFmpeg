using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using SupperFFmpeg.Views;

namespace SupperFFmpeg;

public partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new Window();
        m_window.SystemBackdrop = new MicaBackdrop();
        m_window.Content = new MainPage();
        m_window.Activate();
    }

    private Window m_window;
}

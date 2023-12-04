using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.ViewModels;

namespace SupperFFmpeg.Views;

public sealed partial class RecodePage : Page
{
    public RecodePage()
    {
        this.InitializeComponent();
        this.ViewModel = AppLifeRegister.GetService<RecodeViewModel>();
    }

    public RecodeViewModel ViewModel { get; }
}

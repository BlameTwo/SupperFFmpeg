using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel.DataTransfer;

namespace SupperFFmpeg.Views;

public sealed partial class MainPage : Page
{
    private FrameworkElement _draggingElement;
    public MainPage()
    {
        this.InitializeComponent();
    }
}

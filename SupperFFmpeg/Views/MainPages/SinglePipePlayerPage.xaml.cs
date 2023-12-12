using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.Models;
using SupperFFmpeg.ViewModels.MainViewModels;

namespace SupperFFmpeg.Views.MainPages;

public sealed partial class SinglePipePlayerPage : Page
{
    public SinglePipePlayerPage()
    {
        this.InitializeComponent();
        this.ViewModel = AppLifeRegister.GetService<SinglePipePlayerViewModel>();
    }

    public SinglePipePlayerViewModel ViewModel { get; }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if(e.ClickedItem is MainNavButtonItem item)
        {
            ViewModel.NavigationService.NavigationTo(item.Key, null);
        }
    }
}

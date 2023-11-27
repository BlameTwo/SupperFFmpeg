using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.ViewModels;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace SupperFFmpeg.Views;

public sealed partial class DecomposePage : Page
{
    public DecomposePage()
    {
        this.InitializeComponent();
        this.ViewModel = AppLifeRegister.GetService<DecomposeViewModel>();
    }

    public DecomposeViewModel ViewModel { get; }

    private void Page_DragOver(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {
    }

    private async void Page_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {
        if (e.DataView.Contains(StandardDataFormats.StorageItems))
        {
            var items = await e.DataView.GetStorageItemsAsync();
        }
    }

    private void Page_DragEnter(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {

        e.AcceptedOperation = DataPackageOperation.Link;
        e.Handled = true;
    }
}

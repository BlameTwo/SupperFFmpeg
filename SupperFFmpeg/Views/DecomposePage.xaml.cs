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

}

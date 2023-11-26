using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace SupperFFmpeg.ViewModels;

public sealed partial class DecomposeViewModel(IWindowManagerService windowManagerService):ObservableObject
{
    public IWindowManagerService WindowManagerService { get; } = windowManagerService;
    public FileStreamToolkit FileStreamToolkit => new();

    [ObservableProperty]
    FFmpegSession _FFmpegSession;

    [RelayCommand]
    async Task OpenFile()
    {
        var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(WindowManagerService.Window);
        WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hwnd);
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.FileTypeFilter.Add(".mkv");
        openPicker.FileTypeFilter.Add(".mp4");
        var file = await openPicker.PickSingleFileAsync();
        if (file != null)
        {
            FFmpegStreams.Clear();
            this.FFmpegSession = await FileStreamToolkit.GetFileInfo(file.Path);
            foreach (var item in FFmpegSession.Streams)
            {
                this.FFmpegStreams.Add(item);
            }
        }
    }


    [ObservableProperty]
    ObservableCollection<IFFmpegStream> _FFmpegStreams=new();
}

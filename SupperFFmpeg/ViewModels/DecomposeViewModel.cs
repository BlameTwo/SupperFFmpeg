using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using SupperFFmpeg.ViewModels.ItemViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace SupperFFmpeg.ViewModels;

public sealed partial class DecomposeViewModel(IWindowManagerService windowManagerService,IDataFactory dataFactory):ObservableObject
{
    public IWindowManagerService WindowManagerService { get; } = windowManagerService;
    public IDataFactory DataFactory { get; } = dataFactory;

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
                this.FFmpegStreams.Add(DataFactory.SetData<FFmpegStreamItemViewModel,IFFmpegStream>(item));
            }
        }
    }

    [RelayCommand]
    void OutputSelect()
    {
        var list = this.FFmpegStreams.Where((x)=>x.IsSelect);
    }

    [ObservableProperty]
    ObservableCollection<FFmpegStreamItemViewModel> _FFmpegStreams=new();
}

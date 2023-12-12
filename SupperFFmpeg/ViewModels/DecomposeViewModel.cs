using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using SupperFFmpeg.Models;
using SupperFFmpeg.ViewModels.ControlViewModels;
using SupperFFmpeg.ViewModels.ItemViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace SupperFFmpeg.ViewModels;

public sealed partial class DecomposeViewModel(IWindowManagerService windowManagerService,IDataFactory dataFactory):ObservableObject
{
    public IWindowManagerService WindowManagerService { get; } = windowManagerService;
    public IDataFactory DataFactory { get; } = dataFactory;

    [ObservableProperty]
    FFmpegSession _FFmpegSession;

    [ObservableProperty]
    BitmapImage _ImageSnapshot;

    [ObservableProperty]
    string _FilePath;

    [ObservableProperty]
    FileStreamSessionViewModel _FileStreamViewModel;

    async partial  void OnFilePathChanged(string value)
    {
        if (value != null)
        {
            FFmpegStreams.Clear();
            this.FFmpegSession = await FileStreamToolkit.GetFileInfo(value);
            foreach (var item in FFmpegSession.Streams)
            {
                this.FFmpegStreams.Add(DataFactory.SetItemData<FFmpegStreamItemViewModel, IFFmpegStream>(item));
            }
            var ivalue = Convert.ToDouble(this.FFmpegSession.Format.Duration);
            var stream = await InterceptToolkit.GetSnapshotStream(FFmpegSession, new(0, 0, Random.Shared.Next(0, (int)ivalue)), 0, new(h: 1080, w: 1980));
            BitmapImage bitmapImage = new BitmapImage();
            stream.Position = 0;
            bitmapImage.SetSource(stream.AsRandomAccessStream());
            this.ImageSnapshot = bitmapImage;
        }
    }

    [ObservableProperty]
    ObservableCollection<FFmpegStreamItemViewModel> _FFmpegStreams=new();

    [ObservableProperty]
    FFmpegStreamItemViewModel _SelectItem;

    [ObservableProperty]
    List<DecomposeActionItem> _Tools;

    partial void OnSelectItemChanged(FFmpegStreamItemViewModel value)
    {
        this.FileStreamViewModel = DataFactory.SetControlData<FileStreamSessionViewModel, IFFmpegStream>(value.DataBase);
        this.Tools = DataFactory.CreateTool(value);
    }
}

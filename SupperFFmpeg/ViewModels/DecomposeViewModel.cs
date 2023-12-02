﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using SupperFFmpeg.ViewModels.ItemViewModels;
using System;
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

    public FileStreamToolkit FileStreamToolkit => new();

    [ObservableProperty]
    FFmpegSession _FFmpegSession;

    [ObservableProperty]
    BitmapImage _ImageSnapshot;

    [ObservableProperty]
    string _FilePath;

    async partial  void OnFilePathChanged(string value)
    {
        if (value != null)
        {
            FFmpegStreams.Clear();
            this.FFmpegSession = await FileStreamToolkit.GetFileInfo(value);
            foreach (var item in FFmpegSession.Streams)
            {
                this.FFmpegStreams.Add(DataFactory.SetData<FFmpegStreamItemViewModel, IFFmpegStream>(item));
            }
            var ivalue = Convert.ToDouble(this.FFmpegSession.Format.Duration);
            var bitmap = await InterceptToolkit.GetSnapshot(FFmpegSession, new(0, 0, Random.Shared.Next(0, (int)ivalue)), 0, new(h: 1080, w: 1980));
            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream ms = new();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            bitmapImage.SetSource(ms.AsRandomAccessStream());
            this.ImageSnapshot = bitmapImage;
        }
    }

    [ObservableProperty]
    ObservableCollection<FFmpegStreamItemViewModel> _FFmpegStreams=new();
}

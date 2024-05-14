using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Models.FFmpegStreams;
using SupperFFmpeg.Core.Toolkits;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SupperFFmpeg.ViewModels.ControlViewModels;

public sealed partial class RecodeVideoViewModel : ObservableObject, IRecodeControlViewModel, IDataControl<FFmpegSession>
{
    public RecodeVideoViewModel()
    {
        
    }

    [ObservableProperty]
    FFmpegSession _DataBase;

    [ObservableProperty]
    VideoStream _Stream = null;

    [ObservableProperty]
    BitmapImage _Cover;

    [ObservableProperty]
    ObservableCollection<CodecOutputItem> _CodecOutputItems=new();



    public async Task SetControlDataAsync(FFmpegSession value)
    {
        this.DataBase = value;
        var ivalue = Convert.ToDouble(this.DataBase.Format.Duration);
        Size size = new();
        var videos = this.DataBase.Streams.Where((v) =>
        {
            if (v.CodecType == "video" && v is VideoStream vm)
            {
                this.Stream = vm;
                return true;
            }
            return false;
        });
        if (videos != null && videos.Count() >= 1 && Stream != null)
        {
            var stream = await InterceptToolkit.GetSnapshotStream(DataBase, new(0, 0, Random.Shared.Next(0, (int)ivalue)), 0, size);
            BitmapImage bitmapImage = new BitmapImage();
            stream.Position = 0;
            bitmapImage.SetSource(stream.AsRandomAccessStream());
            this.Cover = bitmapImage;
        }
        var codecList = CodecToolkit.GetVideoOutput();
        foreach (var codec in codecList)
        {
            CodecOutputItems.Add(codec);
        }
    }
}

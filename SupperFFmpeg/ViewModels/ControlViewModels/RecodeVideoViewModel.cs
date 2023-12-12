using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using System;
using System.Collections.ObjectModel;
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
    BitmapImage _Cover;

    [ObservableProperty]
    ObservableCollection<CodecOutputItem> _CodecOutputItems=new();


    [RelayCommand]
    async Task Loaded()
    {
        var ivalue = Convert.ToDouble(this.DataBase.Format.Duration);
        var stream = InterceptToolkit.GetSnapshotStream(DataBase, new(0, 0, Random.Shared.Next(0, (int)ivalue)),0,new(h:1080,w:1920));
        var codecList = CodecToolkit.GetVideoOutput();
        foreach (var codec in codecList)
        {
            CodecOutputItems.Add(codec);
        }
    }

    public void SetControlData(FFmpegSession value)
    {
        this.DataBase = value;
    }
}

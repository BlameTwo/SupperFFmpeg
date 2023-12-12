using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using System.Collections.Generic;

namespace SupperFFmpeg.ViewModels;

partial class RecodeViewModel
{
    public IFileSelectService FileSelectService { get; }
    public IDataFactory DataFactory { get; }

    [ObservableProperty]
    IRecodeControlViewModel _RecodeControlViewModel;

    [ObservableProperty]
    FFmpegSession _FFmpegSession;

    [ObservableProperty]
    int _RecodeSelect = -1;


    [ObservableProperty]
    string _InputFileName;

    /// <summary>
    /// 显式支持的编码器
    /// </summary>
    [ObservableProperty]
    List<CodecOutputItem> _CodecVideoListSource;


    partial void OnRecodeSelectChanged(int value)
    {
        switch (value)
        {
            case 0:
                this.RecodeControlViewModel = DataFactory.CreateVideoRecode(this.FFmpegSession);
                break;
            case 1:
                this.RecodeControlViewModel = DataFactory.CreateAudioViewModel(this.FFmpegSession);
                break;
        }
    }


    async partial void OnInputFileNameChanged(string value)
    {
        this.FFmpegSession = await FileStreamToolkit.GetFileInfo(value);
    }
}

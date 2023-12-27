using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

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

    [ObservableProperty]
    string _OutputFileName;

    /// <summary>
    /// 显式支持的编码器
    /// </summary>
    [ObservableProperty]
    List<CodecOutputItem> _CodecVideoListSource;

    [ObservableProperty]
    CodecOutputItem _CodecVideoItem;

    /// <summary>
    /// 是否存在视频流
    /// </summary>
    [ObservableProperty]
    bool _IsVideoExists;

    /// <summary>
    /// 是否存在音频流
    /// </summary>
    [ObservableProperty]
    bool _IsAudioExists;                                           
}
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;

namespace SupperFFmpeg.Contracts.Services;

/// <summary>
/// FFmpeg任务接口
/// </summary>
public interface IFFmpegTaskItemService
{
    public string Name { get; set; }

    public string Guid { get; }

    public string Description { get; set; }

    public Process BaseProcess { get; }

    public IRelayCommand ActionCommand { get; }

    public object Result { get; set; }

    public string IsSuccess { get; }
}

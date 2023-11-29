using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SupperFFmpeg.Contracts.Services;
using System.Diagnostics;

namespace SupperFFmpeg.Contracts;

public sealed partial class FFmpegTaskItemService :ObservableObject, IFFmpegTaskItemService
{
    public string Name { get; set; }

    public string Guid => System.Guid.NewGuid().ToString();

    public string Description { get; set; }

    public Process BaseProcess { get; }


    [RelayCommand]
    void Action()
    {

    }

    public object Result { get; set; }
    public string IsSuccess { get; }
}

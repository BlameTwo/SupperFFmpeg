using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Models;

namespace SupperFFmpeg.ViewModels.ControlViewModels;

public sealed partial class RecodeAudioViewModel
    : ObservableObject,
        IRecodeControlViewModel,
        IDataControl<FFmpegSession>
{
    [ObservableProperty]
    public FFmpegSession _DataBase;

    public void SetControlData(FFmpegSession value)
    {
        this.DataBase = value;
    }
}

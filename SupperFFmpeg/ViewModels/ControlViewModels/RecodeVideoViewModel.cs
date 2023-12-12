using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Models;

namespace SupperFFmpeg.ViewModels.ControlViewModels;

public sealed partial class RecodeVideoViewModel : ObservableObject, IRecodeControlViewModel, IDataControl<FFmpegSession>
{
    [ObservableProperty]
    FFmpegSession _DataBase;

    public void SetControlData(FFmpegSession value)
    {
        this.DataBase = value;
    }
}

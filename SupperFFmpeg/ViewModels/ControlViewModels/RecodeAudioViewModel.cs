using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Models;
using System.Threading.Tasks;

namespace SupperFFmpeg.ViewModels.ControlViewModels;

public sealed partial class RecodeAudioViewModel
    : ObservableObject,
        IRecodeControlViewModel,
        IDataControl<FFmpegSession>
{
    [ObservableProperty]
    public FFmpegSession _DataBase;


    public async Task SetControlDataAsync(FFmpegSession value)
    {
        this.DataBase = value;
        await Task.CompletedTask;
    }
}

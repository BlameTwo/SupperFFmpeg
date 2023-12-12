using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using SupperFFmpeg.ViewModels.ControlViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupperFFmpeg.ViewModels;

public sealed partial class RecodeViewModel : ObservableRecipient
{
    public RecodeViewModel(IFileSelectService fileSelectService,IDataFactory dataFactory)
    {
        FileSelectService = fileSelectService;
        DataFactory = dataFactory;
    }

    public IFileSelectService FileSelectService { get; }
    public IDataFactory DataFactory { get; }

    [ObservableProperty]
    IRecodeControlViewModel _RecodeControlViewModel;

    [ObservableProperty]
    FFmpegSession _FFmpegSession;

    [ObservableProperty]
    int _RecodeSelect = -1;

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

    [ObservableProperty]
    string _InputFileName;

    async partial void OnInputFileNameChanged(string value)
    {
        this.FFmpegSession = await FileStreamToolkit.GetFileInfo(value);
    }

    [RelayCommand]
    async Task OpenFileAsync()
    {
        var fileStorage = await FileSelectService.OpenFileAsync(
            new List<string>() { ".mp4", ".mkv" }
        );
        this.InputFileName = fileStorage.Path;
    }
}

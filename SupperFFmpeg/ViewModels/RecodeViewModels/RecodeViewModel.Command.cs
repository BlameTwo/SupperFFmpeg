using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupperFFmpeg.ViewModels;

partial class RecodeViewModel
{
    [RelayCommand]
    async Task OpenFileAsync()
    {
        var fileStorage = await FileSelectService.OpenFileAsync(
            new List<string>() { ".mp4", ".mkv" }
        );
        if (fileStorage == null) return;
        this.InputFileName = fileStorage.Path;
    }
}

using SupperFFmpeg.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace SupperFFmpeg.Contracts;

public sealed class FileSelectService : IFileSelectService
{
    public FileSelectService(IWindowManagerService windowManagerService)
    {
        WindowManagerService = windowManagerService;
    }

    public IWindowManagerService WindowManagerService { get; }

    public async Task<StorageFile> GetSaveFileAsync(IList<string> filter)
    {
        var savePicker = new Windows.Storage.Pickers.FileSavePicker();
        WinRT.Interop.InitializeWithWindow.Initialize(savePicker, WinRT.Interop.WindowNative.GetWindowHandle(WindowManagerService.Window));
        savePicker.FileTypeChoices.Add("Save File Extention", filter);
        var result = await savePicker.PickSaveFileAsync();
        return result;
    }



    public async Task<StorageFile> OpenFileAsync(IList<string> filter)
    {
        var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

        WinRT.Interop.InitializeWithWindow.Initialize(openPicker,WinRT.Interop.WindowNative.GetWindowHandle(WindowManagerService.Window));
        foreach (var file in filter)
        {
            openPicker.FileTypeFilter.Add(file);
        }
        openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
        var result =  await openPicker.PickSingleFileAsync();
        return result;
    }

}

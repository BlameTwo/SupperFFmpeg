using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Models;
using SupperFFmpeg.ViewModels.ControlViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupperFFmpeg.Contracts;

public sealed class DataFactory : IDataFactory
{
    public async Task<T> SetControlData<T, ControlValue>(ControlValue data)
        where T : IDataControl<ControlValue>
    {
        var tvalue = AppLifeRegister.GetService<T>();
        await tvalue.SetControlDataAsync(data);
        return tvalue;
    }

    public T SetItemData<T, Value>(Value data)
        where T : IItemData<Value>
    {
        var tvalue = AppLifeRegister.GetService<T>();
        tvalue.SetItemData(data);
        return tvalue;
    }

    public List<DecomposeActionItem> CreateTool(
        ViewModels.ItemViewModels.FFmpegStreamItemViewModel value
    )
    {
        switch (value.DataBase.CodecType)
        {
            case "audio":
                return new List<DecomposeActionItem>()
                {
                    new() { FontIcon = "\uE8D6", Name = "导出MP3" }
                };
            case "subtitle":
                return new List<DecomposeActionItem>()
                {
                    new() { FontIcon = "\uED1E", Name = "导出源字幕文件" }
                };
            case "video":
                return new List<DecomposeActionItem>()
                {
                    new() { FontIcon = "\uE714", Name = "导出MP4" }
                };
        }
        return null;
    }

    public async Task< IRecodeControlViewModel> CreateVideoRecode(FFmpegSession fFmpegSession)
    {
        var vm = AppLifeRegister.GetService<RecodeVideoViewModel>();
        await vm.SetControlDataAsync(fFmpegSession);
        return vm;
    }

    public async Task<IRecodeControlViewModel> CreateAudioViewModel(FFmpegSession fFmpegSession)
    {
        var vm = AppLifeRegister.GetService<RecodeAudioViewModel>();
        await vm.SetControlDataAsync(fFmpegSession);
        return vm;
    }
}

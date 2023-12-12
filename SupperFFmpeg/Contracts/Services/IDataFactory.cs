using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Models;
using System.Collections.Generic;

namespace SupperFFmpeg.Contracts.Services;

public interface IDataFactory
{
    public T SetItemData<T, Value>(Value data)
        where T : IItemData<Value>;

    public T SetControlData<T, ControlValue>(ControlValue data)
        where T:IDataControl<ControlValue>;

    public List<DecomposeActionItem> CreateTool(ViewModels.ItemViewModels.FFmpegStreamItemViewModel value);


    public IRecodeControlViewModel CreateVideoRecode(FFmpegSession fFmpegSession);

    public IRecodeControlViewModel CreateAudioViewModel(FFmpegSession fFmpegSession);
}

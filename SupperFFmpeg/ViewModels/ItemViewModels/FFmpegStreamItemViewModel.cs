using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Contracts.Models;

namespace SupperFFmpeg.ViewModels.ItemViewModels;

public sealed partial class FFmpegStreamItemViewModel:ObservableObject, IItemData<IFFmpegStream>
{

    public bool IsSelect { get; set; }
    public IFFmpegStream DataBase { get; set; }

    public void SetData(IFFmpegStream value)
    {
        this.DataBase = value;
    }

}

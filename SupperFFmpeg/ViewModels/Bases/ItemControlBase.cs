using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Contracts.Models;

namespace SupperFFmpeg.ViewModels.Bases;

public class ItemControlBase<T> : IItemData<IFFmpegStream>
{
    public IFFmpegStream DataBase { get; set; }

    public void SetItemData(IFFmpegStream value)
    {
        this.DataBase = value;
    }
}

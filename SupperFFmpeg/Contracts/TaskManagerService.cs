using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SupperFFmpeg.Contracts.Services;

public sealed class FFmpegTaskManager : IFFmpegTaskManager
{
    readonly Dictionary<string,IFFmpegTaskItemService> _items;

    public FFmpegTaskManager()
    {
        _items = new();
    }


    public void AddTaskItem(IFFmpegTaskItemService service)
    {
        if(_items.ContainsKey(service.Guid))
        {
            throw new System.ArgumentException("相同任务");
        }
        _items.Add(service.Guid, service);
    }

    public ObservableCollection<IFFmpegTaskItemService> GetTaskItems()
    {
        ObservableCollection<IFFmpegTaskItemService> fFmpegTaskItemServices = new();
        var list =  _items.ToList();
        foreach(var item in list)
        {
            fFmpegTaskItemServices.Add(item.Value);
        }
        return fFmpegTaskItemServices;
    }

    public void RemoveTaskItem(string Guid)
    {
        _items.Remove(Guid);
    }
}

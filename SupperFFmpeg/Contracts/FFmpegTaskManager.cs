using SupperFFmpeg.Contracts.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SupperFFmpeg.Contracts;

public sealed class FFmpegTaskManager : IFFmpegTaskManager
{
    private readonly Dictionary<string, IFFmpegTaskItemService> _taskItems;
    public FFmpegTaskManager()
    {
        _taskItems = new();
    }
    public void AddTaskItem(IFFmpegTaskItemService service)
    {
        if (_taskItems.ContainsKey(service.Guid))
        {
            throw new System.ArgumentException("已经存在相同名称的任务");
        }
        _taskItems.Add(service.Guid, service);
    }

    public ObservableCollection<IFFmpegTaskItemService> GetTaskItems()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveTaskItem(string Guid)
    {
        throw new System.NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupperFFmpeg.Contracts.Services;

public interface IFFmpegTaskManager
{
    public ObservableCollection<IFFmpegTaskItemService> GetTaskItems();

    public void AddTaskItem(IFFmpegTaskItemService service);

    public void RemoveTaskItem(string Guid);

}

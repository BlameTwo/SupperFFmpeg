using SupperFFmpeg.ViewModels;
using System.Collections.Generic;

namespace SupperFFmpeg.Models;

public class MainNavButtonItem
{
    public string Key { get; set; }

    public string Icon { get; set; }

    public string Title { get; set; }


    public static List<MainNavButtonItem> GetSinglePlayer()
    {
        List<MainNavButtonItem> items = new()
        {
            new(){Title = "音视频转码",Icon="\uE84F", Key = typeof(RecodeViewModel).FullName},
            new(){Title = "纯音频编码",Icon="\uEC4F",},
            new(){Title = "音视频分解",Icon="\uE96A", Key = typeof(DecomposeViewModel).FullName},
            new(){Title = "混流",Icon="\uE93E"},
            new(){Title = "压缩",Icon="\uE945"}
        };
        return items;
    }
}

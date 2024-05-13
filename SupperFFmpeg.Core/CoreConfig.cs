using SupperFFmpeg.Core.Common;
using System.Collections.Generic;
using System.IO;
using SupperFFmpeg.Core.Models.Enums;

namespace SupperFFmpeg.Core;

public static class CoreConfig
{
    static CoreConfig()
    {
        Instance = new();
    }
    public static FFmpegCoreInstance Instance { get; }
}

public class FFmpegCoreInstance
{
    /// <summary>
    /// FFmpeg Folder
    /// </summary>
    public string FFMEFolder { get; set; }

    /// <summary>
    /// 缓存文件个数
    /// </summary>
    public long Caches { get; set; }

    /// <summary>
    /// 缓存文件夹存档
    /// </summary>
    public string CacheFolder { get; set; }

    public override string ToString()
    {
        return $"FFmpeg文件夹位置:{FFMEFolder}";
    }

    public async Task<string> GetVersion()
    {
        List<string> list = new() { "version" };
        PowerShellProcesser processer = new PowerShellProcesser(FFmpegFile.FFmpeg);
        processer.Arguments = list;
        await processer.BuilderStart();
        return processer.Result;
    }
}
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
    public static FFmpegCoreInstalce Instance { get; }
}

public class FFmpegCoreInstalce
{
    /// <summary>
    /// FFmpeg Folder
    /// </summary>
    public string FFMEFolder { get; set; }


    public override string ToString()
    {
        return $"FFmpeg文件夹位置:{FFMEFolder}";
    }

    public void GetVersion()
    {
        List<string> list = new() { "version" };
        var process =  ProcessBuilder.CreateProcess(FFmpegFile.FFmpeg,list).Start();
    }
}
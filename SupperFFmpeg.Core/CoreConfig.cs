using SupperFFmpeg.Core.Common;
using System.Collections.Generic;
using System.IO;

namespace SupperFFmpeg.Core;

public static class CoreConfig
{
    public static FFmpegCoreInstalce Instance { get; set; }
}

public class FFmpegCoreInstalce
{
    /// <summary>
    /// FFmpeg Folder
    /// </summary>
    public string FFMEFolder { get; set; }


    public override string ToString()
    {
        return $"FFmpeg文件位置:{FFMEFolder}";
    }

    public void GetVersion()
    {
        List<string> list = new() { "version" };
        var process =  ProcessBuilder.CreateProcess(Path.Combine(FFMEFolder, "\\ffmpeg.exe"),list).Start();

    }
}
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SupperFFmpeg.Core.Models.Enums;

namespace SupperFFmpeg.Core.Common;

public static class ProcessBuilder
{
    public static Process CreateProcess(FFmpegFile fileName, List<string> argument)
    {
        Process pos = new();
        var argumentStr = string.Join(" ", argument);
        ProcessStartInfo info =
            new()
            {
                FileName = CoreConfig.Instance.FFMEFolder + (fileName == FFmpegFile.FFmpeg ? "\\ffmpeg.exe" : fileName == FFmpegFile.FFplay ? "\\ffplay.exe" : "\\ffprobe.exe"),
                Arguments = " " + argumentStr,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = CoreConfig.Instance.FFMEFolder,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardInputEncoding = Encoding.UTF8,
                UseShellExecute = false
            };
        
        pos.StartInfo = info;
        return pos;
    }

    public static ProcessStartInfo CreateProcessInfo(FFmpegFile fileName,List<string> argument)
    {
        var argumentStr = string.Join(" ", argument);
        ProcessStartInfo info =
            new()
            {
                FileName = CoreConfig.Instance.FFMEFolder + (fileName == FFmpegFile.FFmpeg ? "\\ffmpeg.exe" : fileName == FFmpegFile.FFplay ? "\\ffplay.exe" : "\\ffprobe.exe"),
                Arguments = " " + argumentStr,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };
        return info;
    }
}

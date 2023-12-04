using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using SupperFFmpeg.Core.Arguments.Processers;
using SupperFFmpeg.Core.Arguments;
using SupperFFmpeg.Core.Models;
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

    public static PowerShell CreatePowerShellInfo(FFmpegFile fileName,List<string> Arguments)
    {
        var FileName = CoreConfig.Instance.FFMEFolder + (fileName == FFmpegFile.FFmpeg ? "\\ffmpeg.exe" : fileName == FFmpegFile.FFplay ? "\\ffplay.exe" : "\\ffprobe.exe");
        string args = string.Join(" ", Arguments);
        PowerShell PowerShellInstance = PowerShell.Create();
        PowerShellInstance.AddScript(FileName+" "+args);
        return PowerShellInstance;
    }

    internal static PipeProcesser BuilderSnapshot(this PipeProcesser processer, FFmpegSession session, TimeSpan time, int index, Models.Size size)
    {
        CheckArgument(processer);
        processer.Arguments.Add($"-ss {time.ToString("g")}");
        processer.Arguments.Add($"-i \"{session.Format.Filename}\"");
        processer.Arguments.Add("-f rawvideo");
        processer.Arguments.Add("-map" + $" 0:{index}");
        processer.Arguments.Add("-c:v png");
        processer.Arguments.Add("-vframes 1");
        processer.Arguments.Add("-s" + $" {size.Width}x{size.Height}");
        return processer;
    }

    internal static PowerShellProcesser BuilderHwaccelList(this PowerShellProcesser processer)
    {
        CheckArgument(processer);
        processer.Arguments.Add("-hide_banner");
        processer.Arguments.Add("-encoders");
        return processer;
    }

    internal static PowerShellProcesser BuilderAudioCodec(this PowerShellProcesser processer)
    {
        processer.BuilderCodec();
        processer.Arguments.Add("|Select-String \"audio\"");
        return processer;
    }

    internal static PowerShellProcesser BuilderVideoCodec(this PowerShellProcesser processer)
    {
        processer.BuilderCodec();
        processer.Arguments.Add("|Select-String \"video\"");
        return processer;
    }
    internal static PowerShellProcesser BuilderSubtitleCodec(this PowerShellProcesser processer)
    {
        processer.BuilderCodec();
        processer.Arguments.Add("|Select-String \"subtitles\"");
        return processer;
    }
    
    internal static PowerShellProcesser BuilderImageCodec(this PowerShellProcesser processer)
    {
        processer.BuilderCodec();
        processer.Arguments.Add("|Select-String \"image\"");
        return processer;
    }

    private static PowerShellProcesser BuilderCodec(this PowerShellProcesser processer)
    {
        CheckArgument(processer);
        processer.Arguments.Add("-encoders");
        return processer;
    }

    static void CheckArgument(PipeProcesser processer)
    {
        //./ffmpeg -hide_banner -encoders -hwaccels
        if (processer == null)
            throw new ArgumentException("参数为空");

    }
    static void CheckArgument(PowerShellProcesser processer)
    {
        //./ffmpeg -hide_banner -encoders -hwaccels
        if (processer == null)
            throw new ArgumentException("参数为空");

    }
}
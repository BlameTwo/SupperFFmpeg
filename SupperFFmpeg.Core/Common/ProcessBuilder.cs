

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
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardInputEncoding = Encoding.UTF8,
                StandardOutputEncoding= Encoding.UTF8,
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

    internal static PowerShellProcesser BuilderCodec(this PowerShellProcesser processer, CodecType type)
    {
        CheckArgument(processer);
        processer.Arguments.Add("-encoders");
        
        string codec = string.Empty;
        switch (type)
        {
            case CodecType.Video:
                codec = "video";
                break;
            case CodecType.Audio:
                codec = "audio";
                break;
            case CodecType.Image:
                codec = "image";
                break;
            case CodecType.Subtitle:
                codec = "subtitles";
                break;
            case CodecType.HwaccelVideo:
                processer.Arguments.Add("-hide_banner");
                break;
            case CodecType.HwaccelAudio:
                processer.Arguments.Add("-hide_banner");
                break;
        }
        if(type == CodecType.HwaccelAudio || type == CodecType.HwaccelVideo)
        {
            return processer;
        }
        processer.Arguments.Add($"|Select-String \"{codec}\"");
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
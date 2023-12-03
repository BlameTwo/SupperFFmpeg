using SupperFFmpeg.Core.Arguments.Processers;
using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Models.Enums;
using SupperFFmpeg.Core.Toolkits;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Arguments;

public abstract class Processer<T>
{
    public T Result { get; internal set; }

    public List<string> Arguments { get; private set; }

    private PipeWriter pipWriter;

    public ProcessStartInfo StartInfo { get; internal set; }

    ProcessStartInfo startInfo;

    public Processer(FFmpegFile fFmpegFile)
    {
        Arguments = new();
        FFmpegFile = fFmpegFile;
    }

    private string _pipeName;

    public string PipeName
    {
        get { return _pipeName; }
        set { _pipeName = value; }
    }

    public abstract Task BuilderStart();

    public FFmpegFile FFmpegFile { get; }

}

public static class ProcesserHelper
{
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

    internal static DefaultProcesser BuilderHwaccelList(this DefaultProcesser processer)
    {
        CheckArgument(processer);
        processer.Arguments.Add("-hide_banner");
        processer.Arguments.Add("-encoders");
        return processer;
    }

    static void CheckArgument(PipeProcesser processer)
    {
        //./ffmpeg -hide_banner -encoders -hwaccels
        if (processer == null)
            throw new ArgumentException("参数为空");

    }
    static void CheckArgument(DefaultProcesser processer)
    {
        //./ffmpeg -hide_banner -encoders -hwaccels
        if (processer == null)
            throw new ArgumentException("参数为空");

    }
}

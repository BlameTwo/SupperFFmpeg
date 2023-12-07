using static SupperFFmpeg.Core.Common.Handler.Delegates;

namespace SupperFFmpeg.Core.Arguments.Processers;

public sealed class OutputProgressProcesser : Processer<string>
{
    #region Event
    private OutputProcesserDelegate? outputProcesserHandler;

    public event OutputProcesserDelegate OutputProcesserMessageEvent
    {
        add => outputProcesserHandler += value;
        remove => outputProcesserHandler -= value;
    }

    private ProgressProcesserDelegate? progressProcesserHandler;
   

    public event ProgressProcesserDelegate ProgressProcesserMessageEvent
    {
        add => progressProcesserHandler += value;
        remove => progressProcesserHandler -= value;
    }
    #endregion

    #region 字段
    private TimeSpan currentDuration;
    private TimeSpan totalDuration;
    #endregion


    public OutputProgressProcesser(FFmpegFile fFmpegFile) : base(fFmpegFile)
    {
        
    }

    public ProcessStartInfo StartInfo { get; private set; }

    public override async Task BuilderStart()
    {
        await Task.Run(async () =>
        {
            IsRuning = true;
            using (Process ps = new())
            {
                this.StartInfo = ProcessBuilder.CreateProcessInfo(this.FFmpegFile, this.Arguments);
                ps.StartInfo = this.StartInfo;
                ps.ErrorDataReceived += (sender, result) =>
                {
                    this.outputProcesserHandler?.Invoke(this, result.Data!);
                    SetProgress(result.Data!);
                };
                ps.Start();
                ps.BeginErrorReadLine();
                await ps.WaitForExitAsync();
                currentDuration = TimeSpan.Zero;
                totalDuration = TimeSpan.Zero;
                ps.Close();
                ps.Dispose();
            }
            IsRuning = false;
        });
    }

    private void SetProgress(string data)
    {
        double progressvalue = 0.0;
        if (!string.IsNullOrEmpty(data))
        {
            string durationPattern = @"Duration: (\d{2}:\d{2}:\d{2}\.\d{2})";
            string progressPattern = @"time=([^bitrate]+)";

            Match durationMatch = Regex.Match(data, durationPattern);
            if (durationMatch.Success)
            {
                if (totalDuration == TimeSpan.Zero)
                    totalDuration = TimeSpan.Parse(durationMatch.Groups[1].Value);
            }
            Match progressMatch = Regex.Match(data, progressPattern);
            if (progressMatch.Success)
            {
                currentDuration = TimeSpan.Parse(progressMatch.Groups[1].Value);
                progressvalue =
                    currentDuration.TotalSeconds / totalDuration.TotalSeconds * 100;
                this.progressProcesserHandler?.Invoke(this, progressvalue);
            }
        }
    }
}

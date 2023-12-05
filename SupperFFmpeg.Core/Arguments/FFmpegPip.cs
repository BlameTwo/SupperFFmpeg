namespace SupperFFmpeg.Core.Arguments;

/// <summary>
/// FFmpeg 进程管道
/// </summary>
public abstract class FFmpegPip
{
    NamedPipeServerStream _Readerclient = null;
    
    public FFmpegPip(string pipName, PipeDirection type)
    {
        PipName = pipName;
        Type = type;
    }

    public abstract Stream Reader { get; set; }

    public string PipName { get; }
    public PipeDirection Type { get; }



    public async Task DisconnectAsync()
    {

    }

}
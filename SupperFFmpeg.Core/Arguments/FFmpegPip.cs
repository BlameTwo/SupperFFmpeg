using System.IO.Pipes;
using System.Net.Http.Headers;

namespace SupperFFmpeg.Core.Arguments;

public abstract class FFmpegPip
{
    readonly NamedPipeServerStream _client = null;

    public FFmpegPip(string pipName, PipeDirection type)
    {
        _client = new NamedPipeServerStream(pipName, type);
    }



}
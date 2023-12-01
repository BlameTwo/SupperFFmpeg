using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

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

    public async Task ConnectAsync(CancellationToken token = default)
    {
        _Readerclient = new NamedPipeServerStream(PipName,Type,1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        await _Readerclient.WaitForConnectionAsync(token).ConfigureAwait(false);
        if (!_Readerclient.IsConnected)
            throw new TaskCanceledException();
    }


    public async Task DisconnectAsync()
    {

    }

}
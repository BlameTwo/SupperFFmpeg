using System;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Arguments;

public class PipeWriter
{
    NamedPipeServerStream _write = null;

    public PipeWriter(string pipeName, PipeDirection pipeDirection)
    {
        PipeName = pipeName;
        PipeDirection = pipeDirection;
    }

    /// <summary>
    /// 连接管道
    /// </summary>
    /// <param name="timeout"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    public bool Connect(Stream stream)
    {
        _write = new NamedPipeServerStream(
            PipeName,
            PipeDirection,
            1,
            PipeTransmissionMode.Byte,
            PipeOptions.Asynchronous,10000,10000
        );
        Thread thread = new(() =>
        {
            StartReader(stream);
        });
        thread.IsBackground = true;
        thread.Start();
        return false;
    }

    private void StartReader(Stream stream)
    {
        Task.Run(async() =>
        {
            await _write.WaitForConnectionAsync();
            if (stream == null)
                throw new ArgumentException("被动写入流错误");
            stream.Seek(0, SeekOrigin.Begin);
            using (StreamReader pipeWriter = new StreamReader(_write))
            {
                if (_write.IsConnected)
                    await pipeWriter.BaseStream.CopyToAsync(stream);
            }
        });
    }

    public async Task Disconnect()
    {
        if (this._write == null)
            return;
        _write.Disconnect();
        _write.Close();
        await _write.DisposeAsync();
    }

    public Stream Stream { get; }
    public string PipeName { get; }
    private readonly PipeDirection PipeDirection;
}

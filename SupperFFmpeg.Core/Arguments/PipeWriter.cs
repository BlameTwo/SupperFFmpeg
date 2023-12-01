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

    StreamReader reader;

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

            _write.WaitForConnection();
            StartReader(stream);
        });
        thread.IsBackground = true;
        thread.Start();
        return false;
    }

    private void StartReader(Stream stream)
    {
        Task.Run(() =>
        {
            if (stream == null)
                throw new ArgumentException("被动写入流错误");
            if (_write.IsConnected)
            {
                stream.Seek(0, SeekOrigin.Begin);
                reader = new StreamReader(_write);
                while (!reader.EndOfStream)
                {
                    reader.BaseStream.CopyTo(stream);
                }
                Bitmap b = new Bitmap(stream);
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

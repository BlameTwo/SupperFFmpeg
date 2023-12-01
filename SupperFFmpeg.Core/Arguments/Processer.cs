using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Models.Enums;
using SupperFFmpeg.Core.Toolkits;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Arguments;

public class Processer
{
    public List<string> Arguments { get; private set; }

    private PipeWriter pipWriter;

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

    public async Task BuilderStart(Stream stream)
    {
        this.PipeName = $"FFMPEGCORE_{PipeToolkit.CreatePipName()}";
        pipWriter = new PipeWriter(PipeName, PipeDirection.InOut);
        Arguments.Add($"\"\\\\.\\pipe\\{PipeName}\" -y");
        using (Process p = new())
        {
            startInfo = ProcessBuilder.CreateProcessInfo(FFmpegFile.FFmpeg, this.Arguments);
            p.StartInfo = startInfo;
            p.ErrorDataReceived += (sender, obj) =>
            {
                Debug.WriteLine(obj.Data);
            };
            pipWriter.Connect(stream);
            p.Start();
            p.BeginErrorReadLine();
            p.WaitForExit();
        };
    }

    public FFmpegFile FFmpegFile { get; }


}

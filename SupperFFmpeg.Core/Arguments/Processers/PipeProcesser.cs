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

public class PipeProcesser:Processer<Stream>
{

    private PipeWriter pipWriter;



    private string _pipeName;

    public PipeProcesser(FFmpegFile fFmpegFile) : base(fFmpegFile)
    {
        this.Result = new MemoryStream();
    }


    public override async Task BuilderStart()
    {
        await Task.Run(() =>
        {
            this.PipeName = $"FFMPEGCORE_{PipeToolkit.CreatePipName()}";
            pipWriter = new PipeWriter(PipeName, PipeDirection.InOut);
            Arguments.Add($"\"\\\\.\\pipe\\{PipeName}\" -y");
            using (Process p = new())
            {
                StartInfo = ProcessBuilder.CreateProcessInfo(FFmpegFile.FFmpeg, this.Arguments);
                p.StartInfo = StartInfo;
                p.ErrorDataReceived += (sender, obj) =>
                {
                    Debug.WriteLine(obj.Data);
                };
                pipWriter.Connect(Result);
                p.Start();
                p.BeginErrorReadLine();
                p.WaitForExit();
            };
        });
    }

    public FFmpegFile FFmpegFile { get; }
}


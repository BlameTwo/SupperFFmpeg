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


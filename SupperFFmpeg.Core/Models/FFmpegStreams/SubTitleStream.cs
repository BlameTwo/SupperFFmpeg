using SupperFFmpeg.Core.Contracts;
using System.ComponentModel;

namespace SupperFFmpeg.Core.Models.FFmpegStreams;

public class SubTitleStream : IFFmpegStream
{
    public int Index { get; set; }
    public string CodeType { get; set; }
    public string CodeName { get; set; }


    public long Size { get; set; }
}

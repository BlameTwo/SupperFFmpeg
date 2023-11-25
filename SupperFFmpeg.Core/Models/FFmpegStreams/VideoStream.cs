using SupperFFmpeg.Core.Contracts;
using System;

namespace SupperFFmpeg.Core.Models.FFmpegStreams;

internal class VideoStream : IFFmpegStream
{
    public int Index { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string CodeType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string CodeName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

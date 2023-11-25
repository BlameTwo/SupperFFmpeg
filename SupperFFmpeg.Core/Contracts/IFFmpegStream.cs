namespace SupperFFmpeg.Core.Contracts;

/// <summary>
/// 分解视频流的模型接口
/// </summary>
public interface IFFmpegStream
{
    public int Index { get; set; }

    public string CodeType { get; set; }

    public string CodeName { get; set; }
}

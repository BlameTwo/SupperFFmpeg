using System.Security.Policy;

namespace SupperFFmpeg.Core.Models;

/// <summary>
/// 目前可使用的输出编码器
/// </summary>
public class CodecOutputItem
{
    /// <summary>
    /// 编码器名称
    /// </summary>
    public string CodecName { get; set; }

    /// <summary>
    /// 拓展名
    /// </summary>
    public string FileExtention { get; set; }

    public bool VideoEnable { get; set; }

    public bool AudioEnable { get; set; }

    public bool SubtitleEnable { get; set; }

    public string Name { get; set; }

}

namespace SupperFFmpeg.Core.Models.Enums;

public enum CodecType
{
    /// <summary>
    /// 视频编码
    /// </summary>
    Video,
    /// <summary>
    /// 音频编码
    /// </summary>
    Audio,
    /// <summary>
    /// 图片编码
    /// </summary>
    Image,
    /// <summary>
    /// 字幕编码
    /// </summary>
    Subtitle,
    /// <summary>
    /// 硬件平台编码
    /// </summary>
    HwaccelAudio, HwaccelVideo
}

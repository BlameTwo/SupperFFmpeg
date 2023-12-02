using SupperFFmpeg.Core.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace SupperFFmpeg.Core.Contracts.Models;

/// <summary>
/// 解析视频流的模型接口
/// </summary>
[JsonConverter(typeof(FFmpegStreamConverter))]
public interface IFFmpegStream
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("codec_type")]
    public string CodecType { get; set; }
    [JsonPropertyName("codec_name")]
    public string CodecName { get; set; }

    /// <summary>
    /// 获得导出扩展名
    /// </summary>
    /// <returns></returns>
    public string ExtentionName();

    /// <summary>
    /// 获得默认导出文件名（不包含扩展名
    /// </summary>
    /// <returns></returns>
    public string FileName();
}
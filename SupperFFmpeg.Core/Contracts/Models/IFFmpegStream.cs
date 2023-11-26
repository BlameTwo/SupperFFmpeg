using SupperFFmpeg.Core.Common.JsonConverters;
using SupperFFmpeg.Core.Models.FFmpegStreams;
using System.Text.Json.Serialization;

namespace SupperFFmpeg.Core.Contracts.Models;

/// <summary>
/// 解析视频流的模型接口
/// </summary>
//[JsonPolymorphic(TypeDiscriminatorPropertyName = "codec_type")]
//[JsonDerivedType(typeof(VideoStream), typeDiscriminator: "video")]
//[JsonDerivedType(typeof(AudioStream), typeDiscriminator: "audio")]
//[JsonDerivedType(typeof(SubTitleStream), typeDiscriminator: "subtitle")]
[JsonConverter(typeof(FFmpegStreamConverter))]
public interface IFFmpegStream
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("codec_type")]
    public string CodecType { get; set; }
    [JsonPropertyName("codec_name")]
    public string CodecName { get; set; }
}

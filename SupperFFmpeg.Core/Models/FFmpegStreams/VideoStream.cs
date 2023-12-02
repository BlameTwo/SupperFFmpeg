using SupperFFmpeg.Core.Contracts.Models;
using System;
using System.Text.Json.Serialization;

namespace SupperFFmpeg.Core.Models.FFmpegStreams;

public class VideoStream : IFFmpegStream
{
    /// <summary>
    /// 索引号
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }
    /// <summary>
    /// 编码器名称
    /// </summary>

    [JsonPropertyName("codec_name")]
    public string CodecName { get; set; }

    /// <summary>
    /// 编码器完整名称
    /// </summary>

    [JsonPropertyName("codec_long_name")]
    public string CodecLongName { get; set; }

    /// <summary>
    /// 编码器配置文件
    /// </summary>

    [JsonPropertyName("profile")]
    public string Profile { get; set; }

    /// <summary>
    /// 文件流的类型
    /// </summary>
    [JsonPropertyName("codec_type")]
    public string CodecType { get; set; }

    /// <summary>
    /// 视频流持续时间，每帧的持续时间
    /// </summary>

    [JsonPropertyName("codec_time_base")]
    public string CodecTimeBase { get; set; }

    /// <summary>
    /// 编码标签，视频流格式
    /// </summary>

    [JsonPropertyName("codec_tag_string")]
    public string CodecTagString { get; set; }

    /// <summary>
    /// codec_tag 编码标签，16进制
    /// </summary>

    [JsonPropertyName("codec_tag")]
    public string CodecTag { get; set; }

    /// <summary>
    /// 视频宽度像素
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// 视频高度像素
    /// </summary>

    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// 编码宽度
    /// </summary>
    [JsonPropertyName("coded_width")]
    public int CodedWidth { get; set; }

    /// <summary>
    /// 编码高度
    /// </summary>
    [JsonPropertyName("coded_height")]
    public int CodedHeight { get; set; }

    /// <summary>
    /// 是否包含B帧，提高压缩
    /// </summary>

    [JsonPropertyName("has_b_frames")]
    public int HasBFrames { get; set; }

    /// <summary>
    /// 采样纵横比，
    /// </summary>

    [JsonPropertyName("sample_aspect_ratio")]
    public string SampleAspectRatio { get; set; }

    /// <summary>
    /// 显示纵横比，例如16：9
    /// </summary>

    [JsonPropertyName("display_aspect_ratio")]
    public string DisplayAspectRatio { get; set; }

    /// <summary>
    /// 像素格式
    /// </summary>
    [JsonPropertyName("pix_fmt")]
    public string PixFmt { get; set; }

    /// <summary>
    /// 编码等级
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    /// <summary>
    /// 色度位置
    /// </summary>
    [JsonPropertyName("chroma_location")]
    public string ChromaLocation { get; set; }

    /// <summary>
    /// 视频流场序，progressive 为逐行扫描
    /// </summary>
    [JsonPropertyName("field_order")]
    public string FieldOrder { get; set; }

    /// <summary>
    /// 提高压缩率
    /// </summary>
    [JsonPropertyName("refs")]
    public int Refs { get; set; }

    /// <summary>
    /// 是否是AVC格式
    /// </summary>
    [JsonPropertyName("is_avc")]
    public string IsAvc { get; set; }

    /// <summary>
    /// NAL单元长度
    /// </summary>
    [JsonPropertyName("nal_length_size")]
    public string NalLengthSize { get; set; }

    /// <summary>
    /// 真实帧率，分数
    /// </summary>
    [JsonPropertyName("r_frame_rate")]
    public string RFrameRate { get; set; }

    /// <summary>
    /// 平均帧率
    /// </summary>
    [JsonPropertyName("avg_frame_rate")]
    public string AvgFrameRate { get; set; }

    /// <summary>
    /// 时间基准
    /// </summary>
    [JsonPropertyName("time_base")]
    public string TimeBase { get; set; }

    /// <summary>
    /// 视频流起始时间戳
    /// </summary>
    [JsonPropertyName("start_pts")]
    public int StartPts { get; set; }

    /// <summary>
    /// 时间流起始时间
    /// </summary>
    [JsonPropertyName("start_time")]
    public string StartTime { get; set; }

    /// <summary>
    /// 采样位数
    /// </summary>
    [JsonPropertyName("bits_per_raw_sample")]
    public string BitsPerRawSample { get; set; }

    [JsonPropertyName("disposition")]
    public Disposition Disposition { get; set; }

    [JsonPropertyName("tags")]
    public Tags Tags { get; set; }

    public string ExtentionName()
    {
        throw new NotImplementedException();
    }

    public string FileName()
    {
        throw new NotImplementedException();
    }
}

public class Disposition
{
    [JsonPropertyName("default")]
    public int Default { get; set; }

    [JsonPropertyName("dub")]
    public int Dub { get; set; }

    [JsonPropertyName("original")]
    public int Original { get; set; }

    [JsonPropertyName("comment")]
    public int Comment { get; set; }

    [JsonPropertyName("lyrics")]
    public int Lyrics { get; set; }

    [JsonPropertyName("karaoke")]
    public int Karaoke { get; set; }

    [JsonPropertyName("forced")]
    public int Forced { get; set; }

    [JsonPropertyName("hearing_impaired")]
    public int HearingImpaired { get; set; }

    [JsonPropertyName("visual_impaired")]
    public int VisualImpaired { get; set; }

    [JsonPropertyName("clean_effects")]
    public int CleanEffects { get; set; }

    [JsonPropertyName("attached_pic")]
    public int AttachedPic { get; set; }

    [JsonPropertyName("timed_thumbnails")]
    public int TimedThumbnails { get; set; }
}

public class Tags
{
    [JsonPropertyName("BPS")]
    public string BPS { get; set; }

    [JsonPropertyName("DURATION")]
    public string DURATION { get; set; }

    [JsonPropertyName("NUMBER_OF_FRAMES")]
    public string NUMBEROFFRAMES { get; set; }

    [JsonPropertyName("NUMBER_OF_BYTES")]
    public string NUMBEROFBYTES { get; set; }

    [JsonPropertyName("_STATISTICS_WRITING_APP")]
    public string STATISTICSWRITINGAPP { get; set; }

    [JsonPropertyName("_STATISTICS_WRITING_DATE_UTC")]
    public string STATISTICSWRITINGDATEUTC { get; set; }

    [JsonPropertyName("_STATISTICS_TAGS")]
    public string STATISTICSTAGS { get; set; }
}

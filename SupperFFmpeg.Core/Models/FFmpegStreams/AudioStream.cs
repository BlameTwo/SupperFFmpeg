using SupperFFmpeg.Core.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace SupperFFmpeg.Core.Models.FFmpegStreams;


public class AudioStream:IFFmpegStream
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("codec_name")]
    public string CodecName { get; set; }

    [JsonPropertyName("codec_long_name")]
    public string CodecLongName { get; set; }

    [JsonPropertyName("profile")]
    public string Profile { get; set; }

    [JsonPropertyName("codec_type")]
    public string CodecType { get; set; }

    [JsonPropertyName("codec_time_base")]
    public string CodecTimeBase { get; set; }

    [JsonPropertyName("codec_tag_string")]
    public string CodecTagString { get; set; }

    [JsonPropertyName("codec_tag")]
    public string CodecTag { get; set; }

    [JsonPropertyName("sample_fmt")]
    public string SampleFmt { get; set; }

    [JsonPropertyName("sample_rate")]
    public string SampleRate { get; set; }

    [JsonPropertyName("channels")]
    public int Channels { get; set; }

    [JsonPropertyName("channel_layout")]
    public string ChannelLayout { get; set; }

    [JsonPropertyName("bits_per_sample")]
    public int BitsPerSample { get; set; }

    [JsonPropertyName("r_frame_rate")]
    public string RFrameRate { get; set; }

    [JsonPropertyName("avg_frame_rate")]
    public string AvgFrameRate { get; set; }

    [JsonPropertyName("time_base")]
    public string TimeBase { get; set; }

    [JsonPropertyName("start_pts")]
    public int StartPts { get; set; }

    [JsonPropertyName("start_time")]
    public string StartTime { get; set; }

    [JsonPropertyName("disposition")]
    public Disposition Disposition { get; set; }

    [JsonPropertyName("tags")]
    public StreamTags Tags { get; set; }
}

public class StreamTags
{
    [JsonPropertyName("language")]
    public string Language { get; set; }

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
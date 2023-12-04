using Newtonsoft.Json;

namespace SupperFFmpeg.Core.Models;

public class OutputCodec
{
    /// <summary>
    /// 音频表示可解码字段
    /// </summary>
    public const string AD = "A....D";

    /// <summary>
    /// 音频表示非可解码字段
    /// </summary>
    public const string A = "A....";




    [JsonProperty("CodecType")]
    public string CodecType { get; set; }

    [JsonProperty("Indent")]
    public string Indent { get; set; }

    [JsonProperty("CodecDescription")]
    public string CodecDescription { get; set; }
}

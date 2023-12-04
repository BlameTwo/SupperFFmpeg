using Newtonsoft.Json;

namespace SupperFFmpeg.Core.Models;

public class OutputCodec
{
    /// <summary>
    /// 音频表示可解码字段
    /// </summary>
    public const string AAD = "A....D";

    /// <summary>
    /// 音频表示非可解码字段
    /// </summary>
    public const string AA = "A....";

    /// <summary>
    /// 带D的都是表示带解码
    /// </summary>
    public const string VVD = "V....D";

    public const string VA = "V....";

    public const string SSD = "S....D";

    public const string SA = "S....";


    [JsonProperty("CodecType")]
    public string CodecType { get; set; }

    [JsonProperty("Indent")]
    public string Indent { get; set; }

    [JsonProperty("CodecDescription")]
    public string CodecDescription { get; set; }
}

namespace SupperFFmpeg.Core.Models;



public class CodeingVideoConfig
{
    /// <summary>
    /// 是否复制视频流
    /// </summary>
    public bool IsCopyVideoStream { get; set; }

    /// <summary>
    /// 是否复制音频流
    /// </summary>
    public bool IsCopyAudioStream { get; set; }

    /// <summary>
    /// 是否自定义Video流索引
    /// </summary>
    public bool IsCustomVideoIndex { get; set; }

    /// <summary>
    /// 是否自定义Audio流索引
    /// </summary>
    public bool IsCustomAudioIndex { get; set; }

    /// <summary>
    /// 是否使用头个视频流和音频流
    /// </summary>
    public bool IsOutputFirstStream { get; set; }

    /// <summary>
    /// 是否打开自动速度
    /// </summary>
    public bool IsAutoSpeed { get; set; }

    public bool IsAutoFrame { get; set; }

    /// <summary>
    /// 是否自动比特率
    /// </summary>
    public bool IsAutoBit { get; set; }

    /// <summary>
    /// 防止画面撕裂，垂直同步，不可用
    /// </summary>
    public bool IsVsync { get; private set; }


    public string VideoCodec { get; private set; }

    public string AudioCodec { get; private set; }

    public void SetCodec(string video,string audio)
    {
        VideoCodec = video;
        AudioCodec = audio;
    }

}


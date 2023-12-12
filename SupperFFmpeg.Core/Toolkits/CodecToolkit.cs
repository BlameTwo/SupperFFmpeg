

namespace SupperFFmpeg.Core.Toolkits;

/// <summary>
/// 解码器信息
/// </summary>
public static class CodecToolkit
{

    private static async Task<string> GetResult(PowerShellProcesser pro)
    {
        await pro.BuilderStart();
        return pro.Result;
    }

    private static List<OutputCodec> FormatOutputCodec(string strline,CodecType codecType)
    {
        List<OutputCodec> codec = new();
        string[] lines = strline.Split(new[] { "\r\n" }, StringSplitOptions.None);
        string pattern = @"(\S+)\s+(\S+)\s+(\S+)\s+(.+)";
        var index = 0;
        if (codecType == CodecType.HwaccelAudio || codecType == CodecType.HwaccelVideo)
            index = 10;
        for (int i = index; i < lines.Length; i++)
        {
            Match match = Regex.Match(lines[i], pattern);

            if (match.Success)
            {
                string indent = match.Groups[1].Value;
                string type = match.Groups[2].Value;
                string description = match.Groups[3].Value;
                codec.Add(
                    new()
                    {
                        CodecType = type,
                        Indent = indent,
                        CodecDescription = description
                    }
                );
            }
        }
        return codec;
    }

    /// <summary>
    /// 获得FFmpeg支持的编码器
    /// </summary>
    /// <param name="type">类型</param>
    /// <returns></returns>
    public async static Task<List<OutputCodec>> GetCodecListAsync(CodecType type)
    {
        PowerShellProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
        pro.BuilderCodec(type);
        var lins = await GetResult(pro);
        return FormatOutputCodec(lins,type);
    }

    /// <summary>
    /// 获得包支持的视频编码器
    /// </summary>
    /// <returns></returns>
    public static List<CodecOutputItem> GetVideoOutput()
    {
        List<CodecOutputItem> items = new()
        {
            new(){ CodecName = "h264", FileExtention = ".mp4", Name = "MP4",VideoEnable=true, AudioEnable = true, SubtitleEnable = true},
            new(){ CodecName = "h265", FileExtention = ".mp4", Name = "MP4-H265",VideoEnable=true, AudioEnable = true, SubtitleEnable = true}
        };
        return items;
    }

    public static List<CodecOutputItem> GetAudioOutput()
    {
        List<CodecOutputItem> items = new()
        {
            new(){ CodecName = "aac", FileExtention = ".mp3", Name = "MP3"},
        };
        return items;
    }
}

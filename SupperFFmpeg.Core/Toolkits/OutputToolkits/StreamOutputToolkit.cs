using SupperFFmpeg.Core.Models.OutputToolkits;

namespace SupperFFmpeg.Core.Toolkits.OutputToolkits;

/// <summary>
/// H254,H265编码转换
/// </summary>
public class StreamOutputToolkit : OutputToolkit
{
    public override List<string> BuilderArgument(CodeingVideoConfig config)
    {
        List<string> arguments = new List<string>();    
        if (config is H265Config hconfig)
        {
            //全局命令：-y覆盖output文件
            arguments.Add("-y");
            //设置输入
            arguments.Add($"-i \"{hconfig.InputPath}\"");
            if (hconfig.IsCopyVideoStream)
            {
                arguments.Add($"-c:v copy");
            }
            else
            {
                //如果是复制流
                arguments.Add($"-c:v {hconfig.VideoCodec}");
            }
            if (hconfig.IsCopyAudioStream)
            {
                arguments.Add("-c:a copy");
            }
            else
            {
                //如果是复制流
                arguments.Add($"-c:a {hconfig.AudioCodec}");
            }

            if (!hconfig.IsCustomVideoIndex)
            {
                arguments.Add("-map 0:v:0?");
            }
            else
            {
                arguments.Add($"-map 0:v:{hconfig.VideoIndexStream}");
            }
            if (!hconfig.IsCustomAudioIndex)
            {
                arguments.Add("-map 0:a:0?");
            }else
                arguments.Add($"-map 0:a:{hconfig.AudioIndexStream}");
            if (!hconfig.IsAutoFrame)
            {
                arguments.Add($"-vframes {hconfig.VideoFrame}");
            }
            arguments.Add("-f mp4");
            arguments.Add($"\"{hconfig.OutputPath}\"");
        }
        return arguments;
    }

    public override Processer<string> BuilderProcesser()
    {
        throw new NotImplementedException();
    }
}

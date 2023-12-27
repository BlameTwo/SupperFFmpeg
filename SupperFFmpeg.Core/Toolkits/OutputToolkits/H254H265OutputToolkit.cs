using SupperFFmpeg.Core.Models.OutputToolkits;

namespace SupperFFmpeg.Core.Toolkits.OutputToolkits;

/// <summary>
/// H254,H265编码转换
/// </summary>
public class H254H265OutputToolkit : OutputToolkit
{
    public override List<string> BuilderArgument(CodeingVideoConfig config)
    {
        List<string> arguments = new List<string>();    
        if (config is H264H265Config hconfig)
        {
            //全局命令：-y覆盖output文件
            arguments.Add("-y");
            //设置输入
            arguments.Add($"-i \"{hconfig.InputPath}\"");
            if (hconfig.IsCopyVideoStream)
            {
                //如果是复制流
                arguments.Add("-c:v copy");
            }
            if (hconfig.IsCopyAudioStream)
                arguments.Add("-c:a copy");
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

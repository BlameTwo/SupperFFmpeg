using SupperFFmpeg.Core.Models.OutputToolkits;

namespace SupperFFmpeg.Core.Toolkits.OutputToolkits;

/// <summary>
/// H254,H265编码转换
/// </summary>
public class H254H265OutputToolkit : OutputToolkit
{
    public override void BuilderArgument(CodeingVideoConfig config)
    {
        if(config is H264H265Config hconfig)
        {

        }
        return;
    }

    public override void BuilderProcesser()
    {
        throw new NotImplementedException();
    }
}

using SupperFFmpeg.Core.Models.Enums;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Arguments.Processers;

public sealed class OutputProcesser : Processer<string>
{
    public OutputProcesser(FFmpegFile fFmpegFile) : base(fFmpegFile)
    {
        
    }

    public override Task BuilderStart()
    {
        throw new System.NotImplementedException();
    }
}

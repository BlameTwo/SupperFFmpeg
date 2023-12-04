using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Models.Enums;
using SupperFFmpeg.Core.Toolkits;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Linq;

namespace SupperFFmpeg.Core.Arguments.Processers;

public class PowerShellProcesser : Processer<string>
{
    public PowerShellProcesser(FFmpegFile fFmpegFile) : base(fFmpegFile)
    {

    }


    public override async Task BuilderStart()
    {
        using (PowerShell ps = ProcessBuilder.CreatePowerShellInfo(FFmpegFile.FFmpeg, this.Arguments))
        {
            PSDataCollection<PSObject> PSOutput = await ps.InvokeAsync();
            this.Result = string.Join("\r\n",PSOutput);
        };
    }
}

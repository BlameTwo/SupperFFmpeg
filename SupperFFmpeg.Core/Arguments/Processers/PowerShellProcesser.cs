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

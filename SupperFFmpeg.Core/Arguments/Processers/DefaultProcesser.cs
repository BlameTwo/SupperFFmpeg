using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Models.Enums;
using SupperFFmpeg.Core.Toolkits;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Arguments.Processers;

public class DefaultProcesser : Processer<string>
{
    public DefaultProcesser(FFmpegFile fFmpegFile) : base(fFmpegFile)
    {

    }

    public override async Task BuilderStart()
    {
        await Task.Run(() =>
        {
            using (Process p = new())
            {
                string stringResult = "";
                StartInfo = ProcessBuilder.CreateProcessInfo(FFmpegFile.FFmpeg, this.Arguments);
                p.StartInfo = StartInfo;
                p.ErrorDataReceived += (sender, obj) =>
                {

                };
                p.OutputDataReceived += (sender, obj) =>
                {
                    stringResult += obj.Data+"\r\n";
                };
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                p.WaitForExit();
                this.Result = stringResult;
            };
        });
    }
}

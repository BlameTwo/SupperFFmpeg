using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SupperFFmpeg.Core.Common;

internal static class ProcessBuilder
{
    public static Process CreateProcess(string fileName, List<string> argument)
    {
        Process pos = new();
        var argumentStr = string.Join(" ", argument);
        ProcessStartInfo info =
            new()
            {
                FileName = fileName,
                Arguments = " " + argumentStr,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = CoreConfig.Instance.FFMEFolder,
                StandardErrorEncoding = System.Text.Encoding.UTF8,
                StandardInputEncoding = System.Text.Encoding.UTF8,
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                UseShellExecute = true
            };
        return pos;
    }
}

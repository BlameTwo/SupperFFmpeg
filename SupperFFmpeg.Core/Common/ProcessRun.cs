namespace SupperFFmpeg.Core.Common;

public static class ProcessRun
{
    public static async Task<string> RunProcessAsync(Process ps)
    {
        string output = "";
        if (ps.StartInfo == null)
            throw new ArgumentException("启动参数为空");
        ps.Start();
        while (!ps.StandardOutput.EndOfStream)
        {
            output += await ps.StandardOutput.ReadLineAsync();
        }
        ps.WaitForExit();
        ps.Close();
        ps.Dispose();
        return output;
    }
}

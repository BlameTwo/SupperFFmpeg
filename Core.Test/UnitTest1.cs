using SupperFFmpeg.Core;
using SupperFFmpeg.Core.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";
            //-show_streams
            //-show_format
            var process = SupperFFmpeg.Core.Common.ProcessBuilder.CreateProcess(
                SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFprobe,
                new() { "-show_streams -show_format \"C:\\Users\\30140\\Desktop\\bin\\Auto.mkv\"", { "-of json"} }
            );
            process.Start();
            var text ="";
            while (!process.StandardOutput.EndOfStream)
            {
                //标准流输出结果
                // 异常流输出的是一些版权信息
                var output = process.StandardOutput.ReadLine();
                text += output;
                Debug.WriteLine(output);
            }
            FFmpegSession session = JsonSerializer.Deserialize<FFmpegSession>(text)!;
            process.WaitForExit();
        }
    }
}

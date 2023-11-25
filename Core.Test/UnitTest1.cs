using SupperFFmpeg.Core;
using System.Diagnostics;

namespace Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("������");
            CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";

            var process = SupperFFmpeg.Core.Common.ProcessBuilder.CreateProcess(
                SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFprobe,
                new() { "-show_streams \"C:\\Users\\30140\\Desktop\\bin\\Auto.mkv\"",{ "-of json"} }
            );
            process.Start();
            var text ="";
            while (!process.StandardOutput.EndOfStream)
            {
                //��׼��������
                // �쳣���������һЩ��Ȩ��Ϣ
                var output = process.StandardOutput.ReadLine();
                text += output;
                Debug.WriteLine(output);
            }
            process.WaitForExit();
        }
    }
}

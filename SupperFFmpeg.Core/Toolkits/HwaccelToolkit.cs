using SupperFFmpeg.Core.Arguments;
using SupperFFmpeg.Core.Arguments.Processers;
using System.IO;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Toolkits;

/// <summary>
/// 硬件加速工具箱
/// </summary>
public class HwaccelToolkit
{
    /// <summary>
    /// 获得当前硬件平台简单信息
    /// </summary>
    /// <returns></returns>
    public async static Task<string> GetHwaccelList()
    {
        return await Task.Run(async () =>
        {
            ///-ss 00:01:00.000 -i "C:\Users\30140\Desktop\bin\Auto.mkv" -f rawvideo -map 0:0 -c:v png -vframes 1 -s 200x400 "\\.\pipe\FFMpegCore_d16e9" -y
            DefaultProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
            pro.BuilderHwaccelList();
            await pro.BuilderStart();
            return pro.Result;
        });
    }
}

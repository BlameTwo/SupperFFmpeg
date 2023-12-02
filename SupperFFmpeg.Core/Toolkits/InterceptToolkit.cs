using SupperFFmpeg.Core.Arguments;
using SupperFFmpeg.Core.Models;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Toolkits;

/// <summary>
/// 截取工具
/// </summary>
public static class InterceptToolkit
{
    /// <summary>
    /// 获得快照
    /// </summary>
    /// <returns></returns>
    public static async Task<Bitmap> GetSnapshot(FFmpegSession session, TimeSpan time,int Index, Models.Size size)
    {
        return await Task.Run(async() =>
        {
            ///-ss 00:01:00.000 -i "C:\Users\30140\Desktop\bin\Auto.mkv" -f rawvideo -map 0:0 -c:v png -vframes 1 -s 200x400 "\\.\pipe\FFMpegCore_d16e9" -y
            Processer pro = new(Models.Enums.FFmpegFile.FFmpeg);
            MemoryStream ms = new();
            if (size.Height == 0)
            {
                size = new Models.Size(h: 720, w: 1280);
            }
            pro.BuilderSnapshot(session, time, Index, size);
            await pro.BuilderStart(ms);
            return new Bitmap(ms);
        });
    }


    internal static Processer BuilderSnapshot(this Processer processer, FFmpegSession session, TimeSpan time,int index, Models.Size size)
    {
        if (processer == null)
            throw new ArgumentException("参数为空");
        processer.Arguments.Add($"-ss {time.ToString("g")}");
        processer.Arguments.Add($"-i \"{session.Format.Filename}\"");
        processer.Arguments.Add("-f rawvideo");
        processer.Arguments.Add("-map" + $" 0:{index}");
        processer.Arguments.Add("-c:v png");
        processer.Arguments.Add("-vframes 1");
        processer.Arguments.Add("-s"+ $" {size.Width}x{size.Height}");
        return processer;
    }
}

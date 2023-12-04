using SupperFFmpeg.Core.Arguments;
using SupperFFmpeg.Core.Common;
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
            PipeProcesser pro = new PipeProcesser(Models.Enums.FFmpegFile.FFmpeg);
            MemoryStream ms = new();
            if (size.Height == 0)
            {
                size = new Models.Size(h: 720, w: 1280);
            }
            pro.BuilderSnapshot(session, time, Index, size);
            await pro.BuilderStart();
            return new Bitmap(pro.Result);
        });
    }


    


}

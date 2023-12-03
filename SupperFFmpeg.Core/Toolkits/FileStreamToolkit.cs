using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Toolkits;

public static class FileStreamToolkit
{

    /// <summary>
    /// 获得一个视频文件的详细信息
    /// </summary>
    /// <param name="path">文件地址</param>
    /// <returns></returns>
    public static async Task<FFmpegSession> GetFileInfo(string path)
    {
        var process = SupperFFmpeg.Core.Common.ProcessBuilder.CreateProcess(
            SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFprobe,
            new() { $"-show_streams -show_format {path}", { "-of json" } }
        );
        var jsonstr = await ProcessRun.RunProcessAsync(process);
        Debug.WriteLine(jsonstr);
        return JsonSerializer.Deserialize<FFmpegSession>(jsonstr)!;
    }


    public static string GetOutputFileName(IFFmpegStream stream)
    {
        return "";
    }
}

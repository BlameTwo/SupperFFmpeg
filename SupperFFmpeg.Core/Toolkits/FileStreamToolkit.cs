using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Toolkits;

public sealed class FileStreamToolkit
{
    private TimeSpan totalDuration;
    private TimeSpan currentDuration;

    /// <summary>
    /// 获得一个视频文件的详细信息
    /// </summary>
    /// <param name="path">文件地址</param>
    /// <returns></returns>
    public async Task<FFmpegSession> GetFileInfo(string path)
    {
        var process = SupperFFmpeg.Core.Common.ProcessBuilder.CreateProcess(
            SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFprobe,
            new() { $"-show_streams -show_format {path}", { "-of json" } }
        );
        var jsonstr = await ProcessRun.RunProcessAsync(process);
        Debug.WriteLine(jsonstr);
        return JsonSerializer.Deserialize<FFmpegSession>(jsonstr)!;
    }

    public async Task<bool> OutputStream(FFmpegSession dataBase, IFFmpegStream stream)
    {
        await Task.Run(() =>
        {
            List<string> paramters =
            new()
            {
                "-i " + dataBase.Format.Filename,
                " -map " + $"0:{stream.Index}",
                " -c " + "copy",
                " D:\\test.srt",
            };
            var process = SupperFFmpeg.Core.Common.ProcessBuilder.CreateProcess(
                SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFmpeg,
                paramters
            );
            process.ErrorDataReceived += (sender, data) =>
            {
                double progressvalue = 0.0;
                if (!string.IsNullOrEmpty(data.Data))
                {
                    string durationPattern = @"Duration: (\d{2}:\d{2}:\d{2}\.\d{2})";
                    string progressPattern = @"time=([^bitrate]+)";

                    Match durationMatch = Regex.Match(data.Data, durationPattern);
                    if (durationMatch.Success)
                    {
                        if (totalDuration == TimeSpan.Zero)
                            totalDuration = TimeSpan.Parse(durationMatch.Groups[1].Value);
                    }
                    Match progressMatch = Regex.Match(data.Data, progressPattern);
                    if (progressMatch.Success)
                    {
                        currentDuration = TimeSpan.Parse(progressMatch.Groups[1].Value);
                        progressvalue =
                            currentDuration.TotalSeconds / totalDuration.TotalSeconds * 100;
                        Debug.WriteLine(progressvalue);
                    }
                }
            };
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        });
        //ffmpeg -i input.mp4 -map 0:index -c copy video.格式
        return true;
    }
}

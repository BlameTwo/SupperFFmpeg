using Microsoft.PowerShell.Commands;
using SupperFFmpeg.Core.Arguments;
using SupperFFmpeg.Core.Arguments.Processers;
using SupperFFmpeg.Core.Common;
using SupperFFmpeg.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SupperFFmpeg.Core.Toolkits;

/// <summary>
/// 硬件加速工具箱
/// </summary>
public static class CodecToolkit
{
    /// <summary>
    /// 获得当前硬件平台简单信息
    /// </summary>
    /// <returns></returns>
    public async static Task<string> GetHwaccelList()
    {
        ///-ss 00:01:00.000 -i "C:\Users\30140\Desktop\bin\Auto.mkv" -f rawvideo -map 0:0 -c:v png -vframes 1 -s 200x400 "\\.\pipe\FFMpegCore_d16e9" -y
        PowerShellProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
        pro.BuilderHwaccelList();
        return await GetResult(pro);
    }

    public static async Task<string> GetResult(PowerShellProcesser pro)
    {
        await pro.BuilderStart();
        return pro.Result;
    }

    private static List<OutputCodec> FormatOutputCodec(string strline)
    {
        List<OutputCodec> codec = new();
        string[] lines = strline.Split(new[] { "\r\n" }, StringSplitOptions.None);
        string pattern = @"(\S+)\s+(\S+)\s+(\S+)\s+(.+)";

        foreach (string line in lines)
        {
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string indent = match.Groups[1].Value;
                string type = match.Groups[2].Value;
                string description = match.Groups[3].Value;
                codec.Add(
                    new()
                    {
                        CodecType = type,
                        Indent = indent,
                        CodecDescription = description
                    }
                );
            }
        }
        return codec;
    }

    /// <summary>
    /// 获得支持的音频编码器
    /// </summary>
    /// <returns></returns>
    public async static Task<List<OutputCodec>> GetAudioCodecList()
    {
        PowerShellProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
        pro.BuilderAudioCodec();
        var lins = await GetResult(pro);
        return FormatOutputCodec(lins);
    }

    public static async Task<List<OutputCodec>> GetVideoCodecList()
    {
        PowerShellProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
        pro.BuilderVideoCodec();
        var lins = await GetResult(pro);
        return FormatOutputCodec(lins);
    }

    public static async Task<List<OutputCodec>> GetImageCodecList()
    {
        PowerShellProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
        pro.BuilderImageCodec();
        var lins = await GetResult(pro);
        return FormatOutputCodec(lins);
    }

    public static async Task<List<OutputCodec>> GetSubtitleCodecList()
    {
        PowerShellProcesser pro = new(Models.Enums.FFmpegFile.FFmpeg);
        pro.BuilderSubtitleCodec();
        var lins = await GetResult(pro);
        return FormatOutputCodec(lins);
    }
}

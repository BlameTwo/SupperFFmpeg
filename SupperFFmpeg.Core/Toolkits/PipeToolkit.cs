using SupperFFmpeg.Core.Arguments;
using System;
using System.Linq;

namespace SupperFFmpeg.Core.Toolkits;

/// <summary>
/// 管道工具
/// </summary>
public static class PipeToolkit
{
    //NamedPipeServerStream

    private static readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghizklmnopqrstuvwxyz0123456789";
    private static Random random = new Random();


    internal static string CreatePipName(int length = 5)
    {
        return new string(Enumerable.Repeat(_chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
    }

}

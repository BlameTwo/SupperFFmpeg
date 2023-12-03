using SupperFFmpeg.Core;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";
var info = await FileStreamToolkit.GetFileInfo("C:\\Users\\30140\\Desktop\\bin\\Auto.mkv");
//var resul2 = await InterceptToolkit.GetSnapshot(info,TimeSpan.FromMinutes(5),0,new());
var result = await HwaccelToolkit.GetHwaccelList();

string[] lines = result.Split(new[] { "\r\n" }, StringSplitOptions.None);
string pattern = @"(\S+)\s+(\S+)\s+(\S+)\s+(.+)";

foreach (string line in lines)
{
    Match match = Regex.Match(line, pattern);

    if (match.Success)
    {
        string indent = match.Groups[1].Value;
        string type = match.Groups[2].Value;
        string description = match.Groups[3].Value;

        Console.WriteLine($"Indent: '{indent}', Type: '{type}', Description: '{description}'");
    }
}
Console.ReadKey();
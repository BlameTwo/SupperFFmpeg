using SupperFFmpeg.Core;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using System.Diagnostics;
using System.Text.Json;

CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";
FileStreamToolkit filestream = new();
var info = await filestream.GetFileInfo("C:\\Users\\30140\\Desktop\\bin\\Auto.mkv");
var result = await InterceptToolkit.GetSnapshot(info,TimeSpan.FromMinutes(5),0,new());
Console.ReadKey();
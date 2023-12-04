using SupperFFmpeg.Core;
using SupperFFmpeg.Core.Toolkits;
using System.Text.RegularExpressions;

CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";
var info = await FileStreamToolkit.GetFileInfo("C:\\Users\\30140\\Desktop\\bin\\Auto.mkv");
//var resul2 = await InterceptToolkit.GetSnapshot(info,TimeSpan.FromMinutes(5),0,new());
var result = await CodecToolkit.GetAudioCodecList();
var result2 = await CodecToolkit.GetVideoCodecList();
var result3 = await CodecToolkit.GetSubtitleCodecList();
var result4 = await CodecToolkit.GetImageCodecList();
Console.ReadKey();
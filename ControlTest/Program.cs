using SupperFFmpeg.Core;
using SupperFFmpeg.Core.Toolkits;

CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";
var info = await FileStreamToolkit.GetFileInfo("C:\\Users\\30140\\Desktop\\bin\\Auto.mkv");
//var resul2 = await InterceptToolkit.GetSnapshot(info,TimeSpan.FromMinutes(5),0,new());
var result = await CodecToolkit.GetCodecListAsync( SupperFFmpeg.Core.Models.Enums.CodecType.Audio);
Console.ReadKey();
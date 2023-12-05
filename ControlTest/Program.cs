using SupperFFmpeg.Core;
using SupperFFmpeg.Core.Arguments.Processers;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Models.OutputToolkits;
using SupperFFmpeg.Core.Toolkits;
using SupperFFmpeg.Core.Toolkits.OutputToolkits;

CoreConfig.Instance.FFMEFolder = "C:\\Users\\30140\\Desktop\\bin";
//var info = await FileStreamToolkit.GetFileInfo("C:\\Users\\30140\\Desktop\\bin\\Auto.mkv");

////var resul2 = await InterceptToolkit.GetSnapshot(info,TimeSpan.FromMinutes(5),0,new());
//var result = await CodecToolkit.GetCodecListAsync(SupperFFmpeg.Core.Models.Enums.CodecType.Audio);
//var image = await InterceptToolkit.GetSnapshot(
//    info,
//    TimeSpan.FromMinutes(5),
//    0,
//    new(h: 1920, w: 1080)
//);

H254H265OutputToolkit toolkit = new();
var arg = new H264H265Config()
{
    IsAutoBit = true,
    IsAutoFrame = true,
    IsAutoSpeed = true,
    IsCopyAudioStream = true,
    IsCopyVideoStream = true,
    IsCustomVideoIndex = true,
    IsOutputFirstStream = false,
    InputPath = "C:\\Users\\30140\\Desktop\\bin\\Auto.mkv",
    OutputPath = "D:\\Test.mp4",
    OutputType = SupperFFmpeg.Core.Models.Enums.Mp4VideoOutputType.Copy,
    VideoIndexStream = 0,
    VideoBit = 30000,
    VideoFrame = 25,
    VideoSpeed = 100
};
var list =  toolkit.BuilderArgument(arg);
OutputProgressProcesser outputProcesser = new OutputProgressProcesser( SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFmpeg);
outputProcesser.Arguments = list;
await outputProcesser.BuilderStart();

Console.ReadKey();

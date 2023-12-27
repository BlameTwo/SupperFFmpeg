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
//MP4帮助类
H254H265OutputToolkit toolkit = new();
//设置H264和H265的编码器配置
var arg = new H264H265Config()
{
    IsAutoBit = true,
    IsAutoFrame = true,
    IsAutoSpeed = true,
    IsCopyAudioStream = true,
    IsCopyVideoStream = true,
    IsCustomVideoIndex = true,
    IsOutputFirstStream = false,
    InputPath = "E:\\进击的巨人\\后篇.mp4",
    OutputPath = "D:\\Test.mp4",
    OutputType = SupperFFmpeg.Core.Models.Enums.Mp4VideoOutputType.Copy,
    VideoIndexStream = 0,
    VideoBit = 30000,
    VideoFrame = 25,
    VideoSpeed = 100
};
Console.WriteLine($"原始地址:{arg.InputPath}");
Console.WriteLine($"自动比特率：{arg.IsAutoBit}");
Console.WriteLine($"原始帧率：{arg.IsAutoFrame}");
Console.WriteLine($"原始速度：{arg.IsAutoSpeed}");
Console.WriteLine($"视频流是否复制（不进行二次编码器编码）：{arg.IsCopyVideoStream}");
Console.WriteLine($"音频流是否复制（不进行二次编码器编码）：{arg.IsCopyAudioStream}");
Console.WriteLine($"输出地址:{arg.OutputPath}");
var list =  toolkit.BuilderArgument(arg);
//初始化输出进度进程
OutputProgressProcesser outputProcesser = new OutputProgressProcesser(SupperFFmpeg.Core.Models.Enums.FFmpegFile.FFmpeg);
//进度更改事件
outputProcesser.ProgressProcesserMessageEvent += OutputProcesser_ProgressProcesserMessageEvent;

void OutputProcesser_ProgressProcesserMessageEvent(object source, double progress)
{
    //打印转换进度
    Console.WriteLine($"当前进度：{Math.Round(progress,2)}%");
}

//输入参数
outputProcesser.Arguments = list;
//开始转换
await outputProcesser.BuilderStart();

Console.ReadKey();

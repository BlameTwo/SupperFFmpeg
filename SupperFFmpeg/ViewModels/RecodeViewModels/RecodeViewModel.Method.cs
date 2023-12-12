using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Toolkits;
using System.Linq;

namespace SupperFFmpeg.ViewModels;

public sealed partial class RecodeViewModel : ObservableRecipient
{
    public RecodeViewModel(IFileSelectService fileSelectService,IDataFactory dataFactory)
    {
        FileSelectService = fileSelectService;
        DataFactory = dataFactory;
        this.CodecVideoListSource = CodecToolkit.GetVideoOutput();
    }

    partial void OnRecodeSelectChanged(int value)
    {
        switch (value)
        {
            case 0:
                this.RecodeControlViewModel = DataFactory.CreateVideoRecode(this.FFmpegSession);
                break;
            case 1:
                this.RecodeControlViewModel = DataFactory.CreateAudioViewModel(this.FFmpegSession);
                break;
        }
    }

    /*
    在输入数据源之后，此源可能存在多个音频或视频流。
    所以催生出两种方式
    1. 单视频单音频轨道编码
    2. 多轨道编码

    首先完成单轨道编码。

    */

    async partial void OnInputFileNameChanged(string value)
    {
        this.FFmpegSession = await FileStreamToolkit.GetFileInfo(value);
        int aindex = 0;
        int vindex = 0;
        this.IsVideoExists =  FileStreamToolkit.IsVideoExists(ref vindex, FFmpegSession.Streams.ToList());
        this.IsAudioExists = FileStreamToolkit.IsAudioExists(ref aindex, FFmpegSession.Streams.ToList());
    }
}

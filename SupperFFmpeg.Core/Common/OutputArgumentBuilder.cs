using SupperFFmpeg.Core.Arguments.Processers;
using SupperFFmpeg.Core.Models;
using System.Collections.Generic;
using System.Drawing;

namespace SupperFFmpeg.Core.Common;

/// <summary>
/// 输出配置
/// </summary>
public static class OutputArgumentBuilder
{
    /// <summary>
    /// 设置视频帧率
    /// </summary>
    /// <returns></returns>
    public static OutputProcesser SetVideoFrame(this OutputProcesser processer,int frame)
    {
        processer.Arguments.Add($"-r {frame}");
        return processer;
    }

    /// <summary>
    /// 设置编码像素大小
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static OutputProcesser SetStreamSize(this OutputProcesser processer,Models.Size size)
    {
        processer.Arguments.Add($"-r {size.Width}x{size.Height}");
        return processer;
    }

    /// <summary>
    /// 打开或关闭B帧参考
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="flage"></param>
    /// <returns></returns>
    public static OutputProcesser SetBFrameState(this OutputProcesser processer, bool flage)
    {
        string mode = flage == true ? "enable" : "disabled";
        processer.Arguments.Add($"-b_ref_mode {mode}");
        return processer;
    }

    /// <summary>
    /// 设置视频质量
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="quality"></param>
    /// <returns></returns>
    public static OutputProcesser SetVideoQuality(this OutputProcesser processer, int quality)
    {
        processer.Arguments.Add($"-cq:v {quality}");
        return processer;
    }

    /// <summary>
    /// 设置音频采样率
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="rateValue"></param>
    /// <returns></returns>
    public static OutputProcesser SetAudioRate(this OutputProcesser processer, int rateValue)
    {
        processer.Arguments.Add($"-ar {rateValue}");
        return processer;
    }

    /// <summary>
    /// 设置音频比特率
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="bitValue"></param>
    /// <returns></returns>
    public static OutputProcesser SetAudioBit(this OutputProcesser processer, string bitValue)
    {
        processer.Arguments.Add($"-b:a {bitValue}");
        return processer;
    }

    /// <summary>
    /// 设置音频编码
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static OutputProcesser SetAudioCode(this OutputProcesser processer, string code)
    {
        processer.Arguments.Add($"-c:a aac {code}");
        return processer;
    }

    /// <summary>
    /// 设置音频通道数量
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="bannle"></param>
    /// <returns></returns>
    public static OutputProcesser SetAudiobannle(this OutputProcesser processer, string bannle)
    {
        processer.Arguments.Add($"-ac {bannle}");
        return processer;
    }

    /// <summary>
    /// 预设缓存，mb单位
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="cache"></param>
    /// <returns></returns>
    public static OutputProcesser SetBufferCache(this  OutputProcesser processer, int cache)
    {
        processer.Arguments.Add($"-rtbufsize {cache}m");
        return processer;
    }
    
    /// <summary>
    /// 最大混流队列，用来保证多任务执行
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="maxQueue"></param>
    /// <returns></returns>
    public static OutputProcesser SetMaxQueue(this  OutputProcesser processer, int maxQueue)
    {
        processer.Arguments.Add($"-max_muxing_queue_size {maxQueue}");
        return processer;
    }
}
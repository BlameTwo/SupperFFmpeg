namespace SupperFFmpeg.Core.Common;

/// <summary>
/// 输出配置
/// </summary>
public static class OutputArgumentBuilder
{
    /// <summary>
    /// 设置输入文件
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public static OutputProgressProcesser SetInput(this OutputProgressProcesser processer, string input)
    {
        Uri uri = new(input);
        if(uri.IsFile)
            processer.Arguments.Add($"-i {input}");
        return processer;
    }

    /// <summary>
    /// 设置输出文件
    /// </summary>
    /// <param name="processer"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static OutputProgressProcesser SetOutput(this OutputProgressProcesser processer, string output)
    {
        Uri uri = new(output);
        if (uri.IsFile)
            processer.Arguments.Add($" {output}");
        return processer;
    }


    /// <summary>
    /// 设置视频帧率
    /// </summary>
    /// <returns></returns>
    public static OutputProgressProcesser SetVideoFrame(this OutputProgressProcesser processer,int frame)
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
    public static OutputProgressProcesser SetStreamSize(this OutputProgressProcesser processer,Models.Size size)
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
    public static OutputProgressProcesser SetBFrameState(this OutputProgressProcesser processer, bool flage)
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
    public static OutputProgressProcesser SetVideoQuality(this OutputProgressProcesser processer, int quality)
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
    public static OutputProgressProcesser SetAudioRate(this OutputProgressProcesser processer, int rateValue)
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
    public static OutputProgressProcesser SetAudioBit(this OutputProgressProcesser processer, string bitValue)
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
    public static OutputProgressProcesser SetAudioCode(this OutputProgressProcesser processer, string code)
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
    public static OutputProgressProcesser SetAudiobannle(this OutputProgressProcesser processer, string bannle)
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
    public static OutputProgressProcesser SetBufferCache(this  OutputProgressProcesser processer, int cache)
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
    public static OutputProgressProcesser SetMaxQueue(this  OutputProgressProcesser processer, int maxQueue)
    {
        processer.Arguments.Add($"-max_muxing_queue_size {maxQueue}");
        return processer;
    }
}
namespace SupperFFmpeg.Core.Models.OutputToolkits;

public sealed class H264H265Config: CodeingVideoConfig
{
	private double frame;
    private double videobit;
	private double videoSpeed;

    /// <summary>
    /// 帧率设置，需要配合IsAutoFrame使用
    /// </summary>
    public double VideoFrame
	{
		get { return frame; }
		set
		{
			if (!this.IsAutoFrame)
				this.frame = value;
        }
	}

	/// <summary>
	/// 视频比特率
	/// </summary>
	public double VideoBit
	{
		get=>videobit;
		set
		{
			if(!IsAutoBit) this.videobit = value;
		}
	}

	/// <summary>
	/// 视频速度
	/// </summary>
	public double VideoSpeed
	{
		get => videoSpeed;
		set
		{
			if(!IsAutoSpeed)this.videoSpeed = value;
		}
	}
}

namespace SupperFFmpeg.Core.Models.OutputToolkits;

public sealed class H264H265Config: CodeingVideoConfig
{
	private double frame;
    private double videobit;
	private double videoSpeed;
    private int videoIndexStream;
    private string outputPath;
    private string inputPath;
    private Mp4VideoOutputType outputType;
    private int audioIndexStream;

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

	/// <summary>
	/// 自定义的视频流Index
	/// </summary>
	public int VideoIndexStream
	{
		get => videoIndexStream;
		set
		{
			if(IsCustomVideoIndex) this.videoIndexStream = value;
		}

	}

	public int AudioIndexStream
	{
		get=>audioIndexStream;
		set
		{
			if(IsCustomAudioIndex)this.audioIndexStream= value;
		}
	}

    public string OutputPath { get => outputPath; set => outputPath = value; }

    public string InputPath { get => inputPath; set => inputPath = value; }

    public Mp4VideoOutputType OutputType { get => outputType; set => outputType = value; }
}

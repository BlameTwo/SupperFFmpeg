

public abstract class Processer<T>
{
    public T Result { get; internal set; }

    public List<string> Arguments { get; private set; }

    private PipeWriter pipWriter;


    public Processer(FFmpegFile fFmpegFile)
    {
        Arguments = new();
        FFmpegFile = fFmpegFile;
    }

    private string _pipeName;

    public string PipeName
    {
        get { return _pipeName; }
        set { _pipeName = value; }
    }

    public abstract Task BuilderStart();

    public FFmpegFile FFmpegFile { get; }

}


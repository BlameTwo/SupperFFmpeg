

public abstract class Processer<T>
{
    public T Result { get; internal set; }

    public List<string> Arguments { get; set; }

    public Processer(FFmpegFile fFmpegFile)
    {
        Arguments = new();
        FFmpegFile = fFmpegFile;
    }

    public abstract Task BuilderStart();

    public FFmpegFile FFmpegFile { get; }

}


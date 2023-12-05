namespace SupperFFmpeg.Core.Toolkits;

public abstract class OutputToolkit
{
    public abstract Processer<string> BuilderProcesser();

    public abstract List<string> BuilderArgument(CodeingVideoConfig config);
}

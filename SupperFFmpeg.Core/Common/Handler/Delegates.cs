namespace SupperFFmpeg.Core.Common.Handler;

public class Delegates
{
    public delegate void OutputProcesserDelegate(object source, string message);


    public delegate void ProgressProcesserDelegate(object source,double progress);
}

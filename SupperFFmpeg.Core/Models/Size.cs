namespace SupperFFmpeg.Core.Models;

/// <summary>
/// 大小 结构体
/// </summary>
public struct Size
{
    public int Height = 0;

    public int Width = 0;

    public Size(int h,int w)
    {
        Height = h; Width = w;
    }

    public override string ToString()
    {
        return $"Height{Height},Width{Width}";
    }
}

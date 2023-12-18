using Microsoft.Xaml.Interactivity;
using Microsoft.UI.Xaml;

namespace SupperFFmpeg.UI.Behaviors;

public class ProgressBehavior<T> : Behavior<T> where T : DependencyObject
{
    /// <summary>
    /// 获取或设置Progress的值
    /// </summary>  
    public double Progress
    {
        get { return (double)GetValue(ProgressProperty); }
        set { SetValue(ProgressProperty, value); }
    }

    /// <summary>
    /// 标识 Progress 依赖属性。
    /// </summary>
    public static readonly DependencyProperty ProgressProperty =
        DependencyProperty.Register("Progress", typeof(double), typeof(ProgressBehavior<T>), new PropertyMetadata(default(double), OnProgressChanged));

    private static void OnProgressChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        ProgressBehavior<T> target = obj as ProgressBehavior<T>;
        double oldValue = (double)args.OldValue;
        double newValue = (double)args.NewValue;
        if (oldValue != newValue)
            target.OnProgressChanged(oldValue, newValue);
    }

    protected virtual void OnProgressChanged(double oldValue, double newValue)
    {
    }
}

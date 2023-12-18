using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;

namespace SupperFFmpeg.UI.Behaviors;

public class EllipseProgressBehavior : ProgressBehavior<Ellipse>
{
    protected override void OnProgressChanged(double oldValue, double newValue)
    {
        UpdateStrokeDashArray();
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        UpdateStrokeDashArray();
    }

    protected virtual double GetTotalLength()
    {
        if (AssociatedObject == null)
            return 0;

        return (AssociatedObject.ActualHeight - AssociatedObject.StrokeThickness) * Math.PI;
    }


    private void UpdateStrokeDashArray()
    {
        if (AssociatedObject == null || AssociatedObject.StrokeThickness == 0)
            return;

        //if (target.ActualHeight == 0 || target.ActualWidth == 0)
        //    return;

        var totalLength = GetTotalLength();
        totalLength = totalLength / AssociatedObject.StrokeThickness;
        var section = Progress * totalLength;
        var result = new DoubleCollection { section, double.MaxValue };
        AssociatedObject.StrokeDashArray = result;
    }
}

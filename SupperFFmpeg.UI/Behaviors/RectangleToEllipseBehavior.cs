﻿using Microsoft.UI.Xaml.Shapes;
using System;

namespace SupperFFmpeg.UI.Behaviors;

public class RectangleToEllipseBehavior : ProgressBehavior<Rectangle>
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


    private void UpdateStrokeDashArray()
    {
        if (AssociatedObject == null || AssociatedObject.ActualHeight == 0 || AssociatedObject.ActualWidth == 0)
            return;

        var radius = Math.Min(AssociatedObject.ActualHeight, AssociatedObject.ActualWidth) / 2;
        radius = radius * Progress;
        AssociatedObject.RadiusX = radius;
        AssociatedObject.RadiusY = radius;
    }
}

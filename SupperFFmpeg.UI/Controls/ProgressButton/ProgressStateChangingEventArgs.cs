﻿using System;

namespace SupperFFmpeg.UI.Controls;

public class ProgressStateChangingEventArgs : EventArgs
{
    public ProgressStateChangingEventArgs(ProgressState oldValue, ProgressState newValue)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }

    public bool Cancel { get; set; }

    public ProgressState OldValue { get; }

    public ProgressState NewValue { get; }
}
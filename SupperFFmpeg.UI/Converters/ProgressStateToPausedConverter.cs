using Microsoft.UI.Xaml.Data;
using SupperFFmpeg.UI.Controls;
using System;

namespace SupperFFmpeg.UI.Converters;

public class ProgressStateToPausedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var state = (ProgressState)value;
        return state == ProgressState.Ready;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

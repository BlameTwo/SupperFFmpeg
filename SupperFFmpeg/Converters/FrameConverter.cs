using Microsoft.UI.Xaml.Data;
using System;

namespace SupperFFmpeg.Converters;

public class FrameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        try
        {
            if (value is string str)
            {
                var splitstr = str.Split('/');
                var result = Math.Round(double.Parse(splitstr[0]) / double.Parse(splitstr[1]), 2);
                return result;
            }
            return value;
        }
        catch (Exception)
        {
            return value;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

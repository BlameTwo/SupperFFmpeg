using Microsoft.UI.Xaml.Data;
using System;

namespace SupperFFmpeg.Converters;

public class LongToTimeSpanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        double doubleValue = 0;
        if(value is string str && double.TryParse(str,out doubleValue))
        {
            TimeSpan time = TimeSpan.FromSeconds(doubleValue);
            return time.ToString("hh\\:mm\\:ss");
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

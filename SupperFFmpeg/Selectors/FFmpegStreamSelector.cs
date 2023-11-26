using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.ViewModels.ItemViewModels;

namespace SupperFFmpeg.Selectors;

public class FFmpegStreamSelector: DataTemplateSelector
{
    public DataTemplate VideoTempalte { get; set; }

    public DataTemplate AudioTemplate { get; set; }

    public DataTemplate SubTitle { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is FFmpegStreamItemViewModel stream)
        {
            switch (stream.DataBase.CodecType)
            {
                case "audio":
                    return AudioTemplate;
                case "subtitle":
                    return SubTitle;
                case "video":
                    return VideoTempalte;
            }
        }
        return null;
    }
}
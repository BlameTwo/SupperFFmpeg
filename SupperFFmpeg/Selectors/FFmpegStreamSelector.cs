using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using SupperFFmpeg.Core.Contracts.Models;
using SupperFFmpeg.ViewModels.ControlViewModels;
using SupperFFmpeg.ViewModels.ItemViewModels;

namespace SupperFFmpeg.Selectors;

public class FFmpegStreamSelector: DataTemplateSelector
{
    public DataTemplate VideoTempalte { get; set; }

    public DataTemplate AudioTemplate { get; set; }

    public DataTemplate SubTitle { get; set; }

    public DataTemplate VideoControlTempate { get; set; }
    public DataTemplate AudioControlTempate { get; set; }
    public DataTemplate SubTitleControlTempate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is FFmpegStreamItemViewModel stream && container is SelectorItem)
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
        }else if(item is FileStreamSessionViewModel itemcontrol && container is ContentControl)
        {
            switch (itemcontrol.DataBase.CodecType)
            {
                case "audio":
                    return AudioControlTempate;
                case "subtitle":
                    return SubTitleControlTempate;
                case "video":
                    return VideoControlTempate;
            }
        }
        return null;
    }
}
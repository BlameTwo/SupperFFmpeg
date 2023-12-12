using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.ViewModels.ControlViewModels;

namespace SupperFFmpeg.Selectors;

public class RecodecControlDataTemplate: DataTemplateSelector
{
    public DataTemplate VideoTemplate { get; set; }

    public DataTemplate AudioTemplate { get; set; }


    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is RecodeVideoViewModel)
            return VideoTemplate;
        if (item is RecodeAudioViewModel)
            return AudioTemplate;
        return null;
    }
}

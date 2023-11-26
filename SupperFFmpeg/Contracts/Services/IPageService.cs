using Microsoft.UI.Xaml.Controls;
using System;
using System.ComponentModel;

namespace SupperFFmpeg.Contracts.Services;

public interface IPageService
{
    Type GetPage(string key);
    void RegisterObject<View, ViewModel>()
        where View : Page
        where ViewModel : INotifyPropertyChanged, INotifyPropertyChanging;
}

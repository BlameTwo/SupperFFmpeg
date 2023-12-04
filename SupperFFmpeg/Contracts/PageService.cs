using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.ViewModels;
using SupperFFmpeg.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace SupperFFmpeg.Contracts;

public sealed class PageService : IPageService
{
    private readonly Dictionary<string, Tuple<Type, Type>> _pageValues;

    public PageService()
    {
        this._pageValues = new();
        RegisterObject<MainPage, MainViewModel>();
        RegisterObject<DecomposePage, DecomposeViewModel>();
        RegisterObject<WorkSpacePage, WorkSpaceViewModel>();
        RegisterObject<RecodePage, RecodeViewModel>();
    }


    /// <summary>
    /// 页面标识
    /// </summary>
    /// <typeparam name="View">继承于Page</typeparam>
    /// <typeparam name="ViewModel">双继承与两个属性更改接口</typeparam>
    public void RegisterObject<View, ViewModel>()
        where View : Page
        where ViewModel : INotifyPropertyChanged, INotifyPropertyChanging =>
        _pageValues.Add(
            typeof(ViewModel).FullName,
            new Tuple<Type, Type>(typeof(View), typeof(ViewModel))
        );

    /// <summary>
    /// 在一个项目中只使用获取页面就可以
    /// </summary>
    /// <returns></returns>
    public Type GetPage(string key)
    {
        _pageValues.TryGetValue(key, out var value);
        if (value is null)
        {
#if DEBUG
            Debug.WriteLine($"未找到{key}类型对象");
#endif
            return null;
        }
        //只返回页面Type
        return value.Item1;
    }

}

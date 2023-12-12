using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts;
using SupperFFmpeg.Models;
using System.Collections.Generic;

namespace SupperFFmpeg.ViewModels.MainViewModels;

public sealed partial class SinglePipePlayerViewModel:ObservableObject
{

    public SinglePipePlayerViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }
    [ObservableProperty]
    List<MainNavButtonItem> _NavigationItems = MainNavButtonItem.GetSinglePlayer();

    public INavigationService NavigationService { get; }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using SupperFFmpeg.Contracts;
using SupperFFmpeg.Contracts.Services;

namespace SupperFFmpeg.ViewModels;

public sealed partial class MainViewModel : ObservableObject
{
    public MainViewModel(IWindowManagerService windowManagerService, INavigationService navigationService,INavigationViewService navigationViewService)
    {
        WindowManagerService = windowManagerService;
        NavigationService = navigationService;
        NavigationViewService = navigationViewService;
        NavigationService.Navigated += NavigationService_Navigated;
    }

    [RelayCommand]
    void Loaded()
    {
        this.NavigationService.NavigationTo(typeof(WorkSpaceViewModel).FullName,null);
    }

    private void NavigationService_Navigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
    {
        var selectedItem = this.NavigationViewService.GetSelectItem(e.SourcePageType);

        if (selectedItem != null)
        {
            this.NavigationSelectItem = selectedItem;
        }
        if (sender is Frame frame)
        {
            this.IsShow = frame.CanGoBack;
        }
    }

    [RelayCommand]
    void GoBack()
    {
        NavigationService.GoBack();
    }

    public IWindowManagerService WindowManagerService { get; }
    public INavigationService NavigationService { get; }
    public INavigationViewService NavigationViewService { get; }

    [ObservableProperty]
    bool _IsShow;

    [ObservableProperty]
    object _NavigationSelectItem;

}

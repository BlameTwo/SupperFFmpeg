using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupperFFmpeg.Contracts;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.ViewModels;
using SupperFFmpeg.ViewModels.ControlViewModels;
using SupperFFmpeg.ViewModels.ItemViewModels;
using SupperFFmpeg.Views;
using System.Threading.Tasks;

namespace SupperFFmpeg;

public static class AppLifeRegister
{
    public static IHost Host { get; private set; }


    public static async Task InitService()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().
            ConfigureServices((context, service) =>
        {
            service.AddSingleton<INavigationService, NavigationService>();
            service.AddSingleton<INavigationViewService, NavigationViewService>();
            service.AddTransient<IPageService, PageService>();
            service.AddSingleton<IWindowManagerService, WindowManagerService>();
            service.AddSingleton<IDataFactory, DataFactory>();
            service.AddTransient<MainPage>();
            service.AddTransient<MainViewModel>(); 
            service.AddTransient<DecomposePage>();
            service.AddTransient<DecomposeViewModel>();
            service.AddTransient<WorkSpacePage>();
            service.AddTransient<WorkSpaceViewModel>();

            #region ItemViewModel
            service.AddTransient<FFmpegStreamItemViewModel>();
            #endregion

            #region ControlViewModel
            service.AddTransient<FileStreamSessionViewModel>();
            #endregion
        }).Build();
        await Host.StartAsync();
    }

    public static T GetService<T>()
    {
        if (Host.Services.GetService(typeof(T)) is not T service)
        {
            return default(T);
        }
        return service;
    }
}

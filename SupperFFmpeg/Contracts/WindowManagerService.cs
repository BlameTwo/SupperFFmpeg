using Microsoft.UI.Xaml;
using SupperFFmpeg.Contracts.Services;

namespace SupperFFmpeg.Contracts;

public class WindowManagerService : IWindowManagerService
{
    private Window window;

    public Window Window
    {
        get => window; set => window = value;
    }
}

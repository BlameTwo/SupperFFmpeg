using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace SupperFFmpeg.Contracts;

public interface INavigationService
{
    public void RegisterView(Frame frame);

    public void UnRegisterView();

    public bool GoBack();

    public bool GoForward();

    public bool NavigationTo(string keyvalue, object paramter);

    public event NavigatedEventHandler Navigated;

    public event NavigationFailedEventHandler NavigationFailed;
}

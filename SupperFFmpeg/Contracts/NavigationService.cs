using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

namespace SupperFFmpeg.Contracts.Services;

public class NavigationService : INavigationService
{
    public NavigationService(IPageService pageService)
    {
        PageService = pageService;
    }

    private object _parameter;

    private Frame _frame;

    public event NavigatedEventHandler Navigated;
    public event NavigationFailedEventHandler NavigationFailed;
    public IPageService PageService { get; }

    public bool GoBack()
    {
        if (_frame.CanGoBack)
        {
            _frame.GoBack();
            return true;
        }
        return false;
    }

    public bool GoForward()
    {
        if (_frame.CanGoForward)
        {
            _frame.GoForward();
            return true;
        }
        return false;
    }

    public bool NavigationTo(string key, object paramter)
    {
        var pageType = PageService.GetPage(key);
        if (pageType == null) return false;
        if (pageType == null)
            return false;
        if (
            _frame != null && (_frame.Content?.GetType() != pageType)
            || paramter != null && !paramter.Equals(_parameter)
        )
        {
            _parameter = paramter;
            return _frame.Navigate(pageType, paramter, new DrillInNavigationTransitionInfo());
        }
        return false;

    }

    public void RegisterView(Frame frame)
    {
        this._frame = frame;
        this._frame.Navigated += this.Navigated;
        this._frame.NavigationFailed += this.NavigationFailed;
    }

    public void UnRegisterView()
    {
        this._frame.Navigated -= this.Navigated;
        this._frame.NavigationFailed -= this.NavigationFailed;
        this._frame = null;
    }
}


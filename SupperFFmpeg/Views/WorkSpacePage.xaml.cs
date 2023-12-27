using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SupperFFmpeg.ViewModels;
using SupperFFmpeg.UI.Controls;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SupperFFmpeg.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkSpacePage : Page
    {
        public WorkSpacePage()
        {
            this.InitializeComponent();
            this.ViewModel = AppLifeRegister.GetService<WorkSpaceViewModel>();
        }

        public WorkSpaceViewModel ViewModel { get; }

        DispatcherTimer timer = new();
        double i = 0;
        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (i < 1 && ProgressButton.State ==  ProgressState.Started)
            {
                i+=0.1;
                ProgressButton.Progress = i;
            }
            else
            {
                ProgressButton.State = ProgressState.Completed;
            }

        }


        private void ProgressButton_StateChanged(object sender, EventArgs e)
        {
            var progressButton = sender as ProgressButton;
            switch (progressButton.State)
            {
                case ProgressState.Ready:
                    break;
                case ProgressState.Started:
                    try
                    {
                    }
                    catch (Exception)
                    {
                        progressButton.State = ProgressState.Faulted;
                    }
                    break;
                case ProgressState.Completed:
                    break;
                case ProgressState.Faulted:
                    break;
            }
        }

        private void ProgressButton_StateChanging(object sender, UI.Controls.ProgressStateChangingEventArgs e)
        {

        }
    }
}

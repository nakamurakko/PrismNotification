using Prism.Ioc;
using PrismNotification.Dialogs;
using SampleApp.Views;
using System.Windows;

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //// https://prismlibrary.com/docs/wpf/dialog-service.html
            //containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            NotificationDialogService.RegisterDialog(containerRegistry);
        }
    }
}

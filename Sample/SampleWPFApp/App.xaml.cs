using Prism.Ioc;
using PrismNotification.WPF.Dialogs;
using SampleWPFApp.Views;
using System.Windows;

namespace SampleWPFApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{

    protected override Window CreateShell()
    {
        return this.Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // https://prismlibrary.com/docs/wpf/dialog-service.html
        NotificationDialogService.RegisterDialog(containerRegistry);
    }

}

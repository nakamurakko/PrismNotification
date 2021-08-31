using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismNotification.Dialogs
{
    public class NotificationDialogService
    {
        public static void RegisterDialog(IContainerRegistry containerRegistry)
        {
            // https://prismlibrary.com/docs/wpf/dialog-service.html
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }

        public static void ShowDialog(IDialogService dialogService, string message, NotificationDialogButtons buttons, Action<IDialogResult> callbackAction)
        {
            dialogService.ShowDialog(
                nameof(NotificationDialog),
                NotificationDialogParam.CreateDialogMessageParam(message, buttons),
                callbackAction);
        }
    }
}

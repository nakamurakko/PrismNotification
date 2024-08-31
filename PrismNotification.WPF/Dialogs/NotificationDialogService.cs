using Prism.Dialogs;
using Prism.Ioc;
using PrismNotification.Dialogs;
using System;

namespace PrismNotification.WPF.Dialogs;

/// <summary>
/// NotificationDialog を使用するための処理一覧。
/// </summary>
public sealed class NotificationDialogService
{

    /// <summary>
    /// NotificationDialog、 NotificationDialogViewModel を IContainerRegistry を使用して登録する。
    /// App.RegisterTypes で 使用する。
    /// </summary>
    /// <param name="containerRegistry">App.RegisterTypes の引数 IContainerRegistry を指定する。</param>
    /// <remarks>
    /// https://prismlibrary.com/docs/wpf/dialog-service.html
    /// </remarks>
    public static void RegisterDialog(IContainerRegistry containerRegistry)
    {
        // https://prismlibrary.com/docs/wpf/dialog-service.html
        containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
    }

    /// <summary>
    /// メッセージボックスを表示する。
    /// </summary>
    /// <param name="dialogService">IDialogService</param>
    /// <param name="message">メッセージ文字列。</param>
    /// <param name="buttons">応答ボタン。</param>
    /// <param name="callbackAction">メッセージ応答後に呼び出すコールバック関数。</param>
    /// <remarks>
    /// IDialogService.ShowDialog を呼び出す。
    /// https://prismlibrary.com/docs/wpf/dialog-service.html#using-the-dialog-service
    /// </remarks>
    public static void ShowDialog(IDialogService dialogService, string message, NotificationDialogButtons buttons, Action<IDialogResult> callbackAction = null)
    {
        dialogService.ShowDialog(
            nameof(NotificationDialog),
            NotificationDialogParam.CreateDialogMessageParam(message, buttons),
            callbackAction);
    }

}

﻿using Prism.Services.Dialogs;

namespace PrismNotification.Dialogs;

/// <summary>
/// NotificationDialog パラメーター用クラス。
/// </summary>
sealed class NotificationDialogParam
{
    /// <summary>
    /// コンストラクター。非公開。
    /// </summary>
    private NotificationDialogParam()
    {

    }

    /// <summary>
    /// ダイアログメッセージを設定した DialogParameters を生成する。
    /// </summary>
    /// <param name="message">ダイアログメッセージ。</param>
    /// <param name="dialogButtons">ダイアログに表示するボタン。</param>
    /// <returns>DialogParameters。</returns>
    public static DialogParameters CreateDialogMessageParam(string message, NotificationDialogButtons dialogButtons = NotificationDialogButtons.Ok)
    {
        DialogParameters result = new DialogParameters()
        {
            { NotificationDialogParamKey.DialogMessage, message },
            { NotificationDialogParamKey.DialogButtons, dialogButtons }
        };

        return result;
    }
}

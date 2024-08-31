namespace PrismNotification.Dialogs;

/// <summary>
/// NotificationDialog パラメーターキー用クラス。
/// </summary>
public sealed class NotificationDialogParamKey
{

    /// <summary>
    /// ダイアログに表示するメッセージ。
    /// </summary>
    public static readonly string DialogMessage = nameof(DialogMessage);

    /// <summary>
    /// ダイアログに表示するボタン。
    /// </summary>
    public static readonly string DialogButtons = nameof(DialogButtons);

    /// <summary>
    /// コンストラクター。非公開。
    /// </summary>
    private NotificationDialogParamKey()
    {
    }

}

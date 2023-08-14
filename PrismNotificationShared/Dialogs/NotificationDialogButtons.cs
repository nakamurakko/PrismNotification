using System;

namespace PrismNotification.Dialogs;

/// <summary>
/// ダイアログボタンの Enum。
/// </summary>
[Flags]
public enum NotificationDialogButtons
{
    Yes = 1,
    No = 2,
    Ok = No << 1,
    Cancel = Ok << 1,
    YesNo = Yes + No,
    OkCancel = Ok + Cancel,
    YesNoCancel = Yes + No + Cancel
}

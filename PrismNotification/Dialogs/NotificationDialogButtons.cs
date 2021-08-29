using System;
using System.Collections.Generic;
using System.Text;

namespace PrismNotification.Dialogs
{
    /// <summary>
    /// ダイアログボタンの Enum。
    /// </summary>
    [Flags]
    public enum NotificationDialogButtons
    {
        Yes = 1,
        No = 2 << 1,
        Ok = 2 << 2,
        Cancel = 2 << 3,
        YesNo = Yes + No,
        OkCancel = Ok + Cancel,
        YesNoCancel = Yes + No + Cancel
    }
}

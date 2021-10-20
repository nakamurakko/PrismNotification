# PrismNotification.WPF

WPF 用 Prism Library の [Dialog Service](https://prismlibrary.com/docs/wpf/dialog-service.html) をベースに、メッセージダイアログを作成しました。
動作は SampleWPFApp プロジェクトで確認できます。

## 事前準備

`App.RegisterTypes()` でメッセージダイアログを登録します。

```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    NotificationDialogService.RegisterDialog(containerRegistry);
}
```

メッセージダイアログを使用したい ViewModel で、 IDialogService を使えるようにします。
([Using the Dialog Service](https://prismlibrary.com/docs/wpf/dialog-service.html#using-the-dialog-service) を参照)

## ShowDialog 呼び出し

`NotificationDialogService.ShowDialog` で呼び出します。

```cs
NotificationDialogService.ShowDialog(
    _dialogService,
    "Hello world.",
    NotificationDialogButtons.YesNoCancel,
    dialogResult =>
    {
        switch (dialogResult.Result)
        {
            case ButtonResult.Yes:
                ClickResult = "Yes button clicked.";
                break;
            case ButtonResult.No:
                ClickResult = "No button clicked.";
                break;
            case ButtonResult.Cancel:
                ClickResult = "Cancel button clicked.";
                break;
            default:
                break;
        }
    });
```

第3引数 は `NotificationDialogButtons` Enum です。

NotificationDialogButtons | 説明
------- | -------
Yes |
No |
Ok |
Cancel |
YesNo | Yes ボタン、 No ボタンを表示。
OkCancel | OK ボタン、 Cancel ボタンを表示。
YesNoCancel | Yes ボタン、 No ボタン、 Cancel ボタンを表示。

`NotificationDialogButtons.Ok` にすれば、 OK ボタンのみ表示します。
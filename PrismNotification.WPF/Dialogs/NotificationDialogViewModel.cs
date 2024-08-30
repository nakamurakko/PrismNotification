using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using PrismNotification.WPF.Properties;

namespace PrismNotification.Dialogs;

/// <summary>
/// NotificationDialog 用 ViewModel。
/// </summary>
/// <remarks>
/// https://prismlibrary.com/docs/wpf/dialog-service.html
/// </remarks>
internal class NotificationDialogViewModel : BindableBase, IDialogAware
{

    public string Title => "Notification";

    public string YesButtonTitle => Resources.YES_BUTTON_TITLE;

    public string NoButtonTitle => Resources.NO_BUTTON_TITLE;

    public string OkButtonTitle => Resources.OK_BUTTON_TITLE;

    public string CancelButtonTitle => Resources.CANCEL_BUTTON_TITLE;

    private string _message;
    public string Message
    {
        get => this._message;
        set => this.SetProperty(ref _message, value);
    }

    private bool _isYesButtonVisible;
    /// <summary>
    /// Yes ボタンの表示可否。
    /// </summary>
    public bool IsYesButtonVisible
    {
        get => this._isYesButtonVisible;
        set => this.SetProperty(ref _isYesButtonVisible, value);
    }

    private bool _isNobuttonVisible;
    /// <summary>
    /// No ボタンの表示可否。
    /// </summary>
    public bool IsNobuttonVisible
    {
        get => this._isNobuttonVisible;
        set => this.SetProperty(ref _isNobuttonVisible, value);
    }

    private bool _isOkButtonVisible;
    /// <summary>
    /// OK ボタンの表示可否。
    /// </summary>
    public bool IsOkButtonVisible
    {
        get => this._isOkButtonVisible;
        set => this.SetProperty(ref _isOkButtonVisible, value);
    }

    private bool _isCancelButtonVisible;
    /// <summary>
    /// キャンセルボタンの表示可否。
    /// </summary>
    public bool IsCancelButtonVisible
    {
        get => this._isCancelButtonVisible;
        set => this.SetProperty(ref _isCancelButtonVisible, value);
    }

    private DelegateCommand<string> _closeDialogCommand;
    public DelegateCommand<string> CloseDialogCommand
    {
        get => this._closeDialogCommand;
        set => this.SetProperty(ref _closeDialogCommand, value);
    }

    // <https://docs.prismlibrary.com/docs/dialogs/dialog-aware.html#dialogcloselistener>
    public DialogCloseListener RequestClose { get; }

    public NotificationDialogViewModel()
    {
        this.CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
    }

    public virtual void RaiseRequestClose(IDialogResult dialogResult)
    {
        this.RequestClose.Invoke(dialogResult);
    }

    protected virtual void CloseDialog(string parameter)
    {
        ButtonResult result = ButtonResult.None;

        if (nameof(NotificationDialogButtons.Yes).ToLower().Equals(parameter?.ToLower()))
        {
            result = ButtonResult.Yes;
        }
        else if (nameof(NotificationDialogButtons.No).ToLower().Equals(parameter?.ToLower()))
        {
            result = ButtonResult.No;
        }
        else if (nameof(NotificationDialogButtons.Ok).ToLower().Equals(parameter?.ToLower()))
        {
            result = ButtonResult.OK;
        }
        else if (nameof(NotificationDialogButtons.Cancel).ToLower().Equals(parameter?.ToLower()))
        {
            result = ButtonResult.Cancel;
        }

        this.RaiseRequestClose(new DialogResult(result));
    }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {

    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        this.Message = parameters.GetValue<string>(NotificationDialogParamKey.DialogMessage);

        NotificationDialogButtons dialogButtons = parameters.GetValue<NotificationDialogButtons>(NotificationDialogParamKey.DialogButtons);

        this.IsYesButtonVisible = dialogButtons.HasFlag(NotificationDialogButtons.Yes);
        this.IsNobuttonVisible = dialogButtons.HasFlag(NotificationDialogButtons.No);
        this.IsOkButtonVisible = dialogButtons.HasFlag(NotificationDialogButtons.Ok);
        this.IsCancelButtonVisible = dialogButtons.HasFlag(NotificationDialogButtons.Cancel);
    }

}

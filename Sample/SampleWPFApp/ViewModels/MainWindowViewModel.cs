using Prism.Commands;
using Prism.Mvvm;
using Prism.Dialogs;
using PrismNotification.Dialogs;

namespace SampleWPFApp.ViewModels;

public sealed class MainWindowViewModel : BindableBase
{

    private readonly IDialogService _dialogService;

    private string _title = "Sample WPF App";
    public string Title
    {
        get => this._title;
        set => this.SetProperty(ref this._title, value);
    }

    private string _clickResult = "";
    public string ClickResult
    {
        get => this._clickResult;
        set => this.SetProperty(ref this._clickResult, value);
    }

    private DelegateCommand _showMessageCommand;
    public DelegateCommand ShowMessageCommand
    {
        get => this._showMessageCommand;
        set => this.SetProperty(ref this._showMessageCommand, value);
    }

    private DelegateCommand _showOkMessageCommand;

    public DelegateCommand ShowOkMessageCommand
    {
        get => this._showOkMessageCommand;
        set => this.SetProperty(ref this._showOkMessageCommand, value);
    }

    /// <summary>
    /// コンストラクター。
    /// </summary>
    /// <param name="dialogService">Dialog Service</param>
    /// <remarks>
    /// https://prismlibrary.com/docs/wpf/dialog-service.html#using-the-dialog-service
    /// </remarks>
    public MainWindowViewModel(IDialogService dialogService)
    {
        this._dialogService = dialogService;

        this.ShowMessageCommand = new DelegateCommand(() => this.ShowMessageCommandExecute());
        this.ShowOkMessageCommand = new DelegateCommand(() => this.ShowOkMessageCommandExecute());
    }

    /// <summary>
    /// Yes、No、Cancel を表示するメッセージダイアログを表示する。
    /// </summary>
    private void ShowMessageCommandExecute()
    {
        NotificationDialogService.ShowDialog(
            this._dialogService,
            "Hello world.",
            NotificationDialogButtons.YesNoCancel,
            dialogResult =>
            {
                switch (dialogResult.Result)
                {
                    case ButtonResult.Yes:
                        this.ClickResult = "Yes button clicked.";
                        break;
                    case ButtonResult.No:
                        this.ClickResult = "No button clicked.";
                        break;
                    case ButtonResult.Cancel:
                        this.ClickResult = "Cancel button clicked.";
                        break;
                    default:
                        break;
                }
            });
    }

    /// <summary>
    /// OK ボタンのみのメッセージダイアログを表示する。
    /// </summary>
    private void ShowOkMessageCommandExecute()
    {
        NotificationDialogService.ShowDialog(this._dialogService, "OK Message.", NotificationDialogButtons.Ok);
    }

}

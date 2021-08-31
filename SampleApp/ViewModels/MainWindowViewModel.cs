using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismNotification.Dialogs;

namespace SampleApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private string _title = "Sample App";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _clickResult = "";
        public string ClickResult
        {
            get => _clickResult;
            set => SetProperty(ref _clickResult, value);
        }

        private DelegateCommand _showMessageCommand;
        public DelegateCommand ShowMessageCommand
        {
            get => _showMessageCommand;
            set => SetProperty(ref _showMessageCommand, value);
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

            ShowMessageCommand = new DelegateCommand(() => ShowMessageCommandExecute());
        }

        private void ShowMessageCommandExecute()
        {
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
        }
    }
}

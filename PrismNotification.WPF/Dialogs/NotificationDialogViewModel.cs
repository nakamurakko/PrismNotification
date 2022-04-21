using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismNotification.WPF.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismNotification.Dialogs
{
    /// <summary>
    /// NotificationDialog 用 ViewModel。
    /// </summary>
    /// <remarks>
    /// https://prismlibrary.com/docs/wpf/dialog-service.html
    /// </remarks>
    class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Notification";

        public string YesButtonTitle => Resources.YES_BUTTON_TITLE;

        public string NoButtonTitle => Resources.NO_BUTTON_TITLE;

        public string OkButtonTitle => Resources.OK_BUTTON_TITLE;

        public string CancelButtonTitle => Resources.CANCEL_BUTTON_TITLE;

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private bool _isYesButtonVisible;
        /// <summary>
        /// Yes ボタンの表示可否。
        /// </summary>
        public bool IsYesButtonVisible
        {
            get => _isYesButtonVisible;
            set => SetProperty(ref _isYesButtonVisible, value);
        }

        private bool _isNobuttonVisible;
        /// <summary>
        /// No ボタンの表示可否。
        /// </summary>
        public bool IsNobuttonVisible
        {
            get => _isNobuttonVisible;
            set => SetProperty(ref _isNobuttonVisible, value);
        }

        private bool _isOkButtonVisible;
        /// <summary>
        /// OK ボタンの表示可否。
        /// </summary>
        public bool IsOkButtonVisible
        {
            get => _isOkButtonVisible;
            set => SetProperty(ref _isOkButtonVisible, value);
        }

        private bool _isCancelButtonVisible;
        /// <summary>
        /// キャンセルボタンの表示可否。
        /// </summary>
        public bool IsCancelButtonVisible
        {
            get => _isCancelButtonVisible;
            set => SetProperty(ref _isCancelButtonVisible, value);
        }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand
        {
            get => _closeDialogCommand;
            set => SetProperty(ref _closeDialogCommand, value);
        }

        public event Action<IDialogResult> RequestClose;

        public NotificationDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
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

            RaiseRequestClose(new DialogResult(result));
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
            Message = parameters.GetValue<string>(NotificationDialogParamKey.DialogMessage);

            var dialogButtons = parameters.GetValue<NotificationDialogButtons>(NotificationDialogParamKey.DialogButtons);

            IsYesButtonVisible = dialogButtons.HasFlag(NotificationDialogButtons.Yes);
            IsNobuttonVisible = dialogButtons.HasFlag(NotificationDialogButtons.No);
            IsOkButtonVisible = dialogButtons.HasFlag(NotificationDialogButtons.Ok);
            IsCancelButtonVisible = dialogButtons.HasFlag(NotificationDialogButtons.Cancel);
        }
    }
}

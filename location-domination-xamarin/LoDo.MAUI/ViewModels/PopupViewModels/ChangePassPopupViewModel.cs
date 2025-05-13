using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.ViewModels.PopupViewModels
{
    public partial class ChangePassPopupViewModel : ObservableObject
    {
        private PasswordChangeState currentState = PasswordChangeState.PhoneNumber;
        [ObservableProperty]
        private bool _isResendEnabled = false;
        [ObservableProperty]
        private int _tabPosition = 0;
        [ObservableProperty]
        private string _phoneNumber;
        [ObservableProperty]
        private string _newPassword;
        [ObservableProperty]
        private string _veriicationCode;
        [ObservableProperty]
        private string _buttonText = "Next";

        private Command _resendClicked;
        public Command ResendClickedCommand =>
            _resendClicked ?? (_resendClicked = new Command(ExecuteResendClickedCommand));

        private Command _nextClicked;
        public Command NextClickedCommand =>
            _nextClicked ?? (_nextClicked = new Command(ExecuteNextClickedCommand));

        public ChangePassPopupViewModel()
        {
            
        }

        void ExecuteNextClickedCommand()
        {
            if (currentState == PasswordChangeState.PhoneNumber && ValidatePhoneNumber(PhoneNumber))
            {
                //TODO: Implement code sending logic here
                ButtonText = "Sumbit";
                currentState = PasswordChangeState.Code;
                IsResendEnabled = true;
                TabPosition++;
                return;
            }
            if (currentState == PasswordChangeState.Code && ValidateCode(VeriicationCode))
            {
                ButtonText = "Finish";
                IsResendEnabled = false;
                currentState = PasswordChangeState.NewPassword;
                TabPosition++;
                return;
            }
            if (currentState == PasswordChangeState.NewPassword && ValidateNewPassword(VeriicationCode))
            {
                //TODO: Close the popup and go to profile page
            }
        }
        void ExecuteResendClickedCommand()
        {
            //TODO: Implement code resending logic here
        }

        private bool ValidatePhoneNumber(string number)
        {
            //TODO: Implement phone validation here
            return true;
        }
        private bool ValidateCode(string code)
        {
            //TODO: Implement code validation here
            return true;
        }

        private bool ValidateNewPassword(string newPassword)
        {
            //TODO: Implement pass validation here
            return true;
        }
    }
    enum PasswordChangeState
    {
        PhoneNumber,
        Code,
        NewPassword
    }

}

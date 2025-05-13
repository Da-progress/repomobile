using CommunityToolkit.Mvvm.ComponentModel;
using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.ViewModels.PopupViewModels
{
    public partial class DeleteAccountPopupViewModel : ObservableObject
    {
        private readonly IPopupNavigation _popupService;

        private Command _yesClicked;
        public Command YesClickedCommand =>
            _yesClicked ?? (_yesClicked = new Command(ExecuteYesClickedCommand));
        private Command _noClicked;
        public Command NoClickedCommand =>
            _noClicked ?? (_noClicked = new Command(ExecuteNoClickedCommand));

        async void ExecuteNoClickedCommand()
        {
            await _popupService.PopAsync();
        }


        async void ExecuteYesClickedCommand()
        {
            await _popupService.PopAsync();
            await Shell.Current.GoToAsync("//MapPage", true);
        }


        public DeleteAccountPopupViewModel(IPopupNavigation popupNavigation)
        {
            _popupService = popupNavigation;
        }
    }
}

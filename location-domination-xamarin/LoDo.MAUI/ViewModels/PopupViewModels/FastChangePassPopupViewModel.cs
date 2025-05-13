using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.ViewModels.PopupViewModels
{
    public partial class FastChangePassPopupViewModel : ObservableObject
    {
        private readonly IPopupNavigation _popupService;

        [ObservableProperty]
        private string _newPassword = "";
        private Command _passChangeClicked;
        public Command PassChangedClickedCommand =>
            _passChangeClicked ?? (_passChangeClicked = new Command(ExecutePassChangedClickedCommand));

        async void ExecutePassChangedClickedCommand()
        {
            await _popupService.PopAsync();
        }

        public FastChangePassPopupViewModel(IPopupNavigation popupNavigation)
        {
            _popupService = popupNavigation;
        }
    }
}

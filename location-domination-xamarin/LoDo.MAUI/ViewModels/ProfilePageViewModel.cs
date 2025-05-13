using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Views.Pages;
using LoDo.MAUI.Views.Popups;
using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoDo.MAUI.Models.DTOs;
using LoDo.MAUI.Services.Implementations;
using Mopups.Services;
using ServiceProvider = LoDo.MAUI.Services.ServiceProvider;

namespace LoDo.MAUI.ViewModels
{
    public partial class ProfilePageViewModel : ModelBase
    {
        private IPopupNavigation _popupService;
        private CacheService _cacheService;

        public ICommand GoToStatsCommand => new Command(OnGoToStatsCommand);
        public ICommand GoToGamesCommand => new Command(OnGoToGamesCommand);
        public ICommand GoToDominationCommand => new Command(OnGoToStatsCommand);
        public ICommand ChangePasswordCommand => new Command(OnChangePasswordCommand);
        public ICommand LogoutCommand => new Command(OnLogoutCommand);
        public ICommand DeleteAccountCommand => new Command(OnDeleteAccountCommand);
        public ICommand EditCommand => new Command(OnGoToStatsCommand);
        public ICommand GoToEditProfileCommand => new Command(OnGoToEditProfileCommand);


        [ObservableProperty] private string _redData;
        [ObservableProperty] private string _greeting;

        public ProfilePageViewModel(IPopupNavigation popupNavigation, CacheService cacheService)
        {
            _popupService = popupNavigation;
            _cacheService = cacheService;
            SetupGreetings();
        }

        private void SetupGreetings()
        {
            try
            {
                var data = _cacheService.GetObject<UserRegisteredDTO>("userData");
                Greeting = $"Welcome, {data.RegisteredPlayer.Username}";
                RedData = $"Registered on {data.RegisteredPlayer.RegisterDateTime.Substring(0, 10)}";
            }
            catch (Exception e)
            {
                Greeting = "Debug mode";
                RedData = "Debug mode";
                Console.WriteLine(e);
            }
        }

        private async void OnLogoutCommand()
        {
            var page = ServiceProvider.GetService<LogoutPopup>();
            await _popupService.PushAsync(page);
        }

        private async void OnChangePasswordCommand()
        {
            var page = ServiceProvider.GetService<ChangePassPopup>();
            await _popupService.PushAsync(page);
        }

        private async void OnDeleteAccountCommand()
        {
            var page = ServiceProvider.GetService<DeleteAccountPopup>();
            await _popupService.PushAsync(page);
        }

        private async void OnGoToStatsCommand()
        {
            await Shell.Current.GoToAsync("/StatsPage", true);
        }

        private async void OnGoToGamesCommand()
        {
            Vibrate();
            var popup = IPlatformApplication.Current.Services.GetService<NotificationBoardPopup>();
            await MopupService.Instance.PushAsync(popup);
            //Shell.Current.GoToAsync("/MyGamesPage", true);
        }

        private void OnGoToEditProfileCommand()
        {
            Shell.Current.GoToAsync($"/{nameof(EditProfilePage)}", true);
        }
    }
}
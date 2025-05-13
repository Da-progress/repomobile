using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LoDo.MAUI.Models.DTOs;
using LoDo.MAUI.Services.Implementations;
using LoDo.MAUI.Views.Pages;
using LoDo.MAUI.Views.Popups;
using LoDo.MAUI.Views.Popups.Technical;
using Mopups.Interfaces;
using Mopups.Services;

namespace LoDo.MAUI.ViewModels
{
    public partial class SettingsPageViewModel : ModelBase
    {
        private IPopupNavigation _popupService;
        private CacheService _cacheService;

        public ICommand OpenNotificationCommand => new Command(OnOpenNotificationCommand);
        public ICommand OpenVibroCommand => new Command(OnOpenVibroCommand);
        public ICommand OpenLanguageCommand => new Command(OnOpenLanguageCommand);
        public ICommand SendFeedbackCommand => new Command(OnSendFeedback);

        [ObservableProperty] private string _redData = "No account has been used";
        [ObservableProperty] private string _greeting = "Welcome to LoDo!";

        public SettingsPageViewModel(IPopupNavigation popupNavigation, CacheService cacheService)
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
            catch (Exception ex)
            {
            }
        }

        private async void OnOpenNotificationCommand()
        {
            try
            {
                Vibrate();
                if(await CheckIfLogged())
                    return;
                _popupService.PushAsync(new NotificationSettingsPopup());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async void OnOpenVibroCommand()
        {
            try
            {
                Vibrate();
                if(await CheckIfLogged())
                    return;
                _popupService.PushAsync(new VibrationSettingsPopup());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async void OnOpenLanguageCommand()
        {
            Vibrate();
            var toats = Toast.Make("Will be done later", ToastDuration.Short);
            await toats.Show();
        }

        private async void OnSendFeedback()
        {
            try
            {
                Vibrate();
                if(await CheckIfLogged())
                    return;
                _popupService.PushAsync(new FeedbackPopup());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        
    }
}
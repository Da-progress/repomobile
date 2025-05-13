using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Views.Popups;
using LoDo.MAUI.Views.Related.BottomViews;
using Microsoft.Maui.Controls.Maps;
using Mopups.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LoDo.MAUI.Models.App;
using LoDo.MAUI.Services.Implementations;
using LoDo.MAUI.Services.Interfaces;
using LoDo.MAUI.Views.Related.Controls.Map;
using Mopups.Services;
using Refit;
using UraniumUI.Icons.MaterialIcons;

namespace LoDo.MAUI.ViewModels
{
    public partial class MapPageViewModel : ModelBase
    {
        public EventHandler UpdateOpenState;
        private IPopupNavigation _popupService;
        private ILoDoApi _api;
        private ApiService _apiService;
        private Command<ImagePin> _pinClicked;

        public Command<ImagePin> PinClickedCommand =>
            _pinClicked ?? (_pinClicked = new Command<ImagePin>(ExecutePinClickedCommand));

        private Command _updateSearchBoolState;

        public Command UpdateSearchBoolStateCommand =>
            _updateSearchBoolState ?? (_updateSearchBoolState = new Command(UpdateSearchBoolState));

        [ObservableProperty] private ObservableCollection<ImagePin> _gamesAndEvents;
        [ObservableProperty] private ObservableCollection<LeaderboardUserModel> _leaderboardUsers;
        [ObservableProperty] private ObservableCollection<string> _openGames ;

        [ObservableProperty] private bool _openGamesOnly = true;
        [ObservableProperty] private bool _isBusy = false;
        [ObservableProperty] private bool _isLeaderboardBusy = false;
        [ObservableProperty] private bool _isOpenGamesBusy = false;
        [ObservableProperty] private bool _isDetails = false;
        [ObservableProperty] private string _selecteLocationName = string.Empty;
        [ObservableProperty] private string _selectedLocationAddress = string.Empty;
        [ObservableProperty] private bool _IsLoggedIn = true;
        
        private ICommand _goToAddLocationPageCommand;

        public ICommand GoToAddLocationPageCommand =>
            _goToAddLocationPageCommand ?? (_goToAddLocationPageCommand = new Command(ExecuteNavigateToAddLocationPageCommand));

        private ICommand _openNotificationsCommand;

        public ICommand OpenNotificationsCommand =>
            _openNotificationsCommand ?? (_openNotificationsCommand = new Command(ExecuteOpenNotifications));
        
        public MapPageViewModel(IPopupNavigation popupNavigation, ApiService apiService, ILoDoApi api)
        {
            _popupService = popupNavigation;
            _api = api;
            GamesAndEvents = new ObservableCollection<ImagePin>();
            //LoadLocations();
        }

        async void ExecuteOpenNotifications()
        {
            if (!Preferences.ContainsKey("isLoggedIn"))
            {
                var popup = IPlatformApplication.Current.Services.GetService<NotificationBoardPopup>();
                await MopupService.Instance.PushAsync(popup);
                return;
            }
            await Shell.Current.GoToAsync("/AddLocationPage",true);
        }
        
        async void ExecuteSearchClickedCommand()
        {
            MapBottomView sheet = new MapBottomView();
            await sheet.ShowAsync();
        }

        private void UpdateSearchBoolState()
        {
            OpenGamesOnly = !OpenGamesOnly;
            Vibrate();
        }

        async void ExecuteNavigateToAddLocationPageCommand()
        {
            if (!Preferences.ContainsKey("isLoggedIn"))
            {
                await MopupService.Instance.PushAsync(new UnregisteredPopup());
                return;
            }
            await Shell.Current.GoToAsync("/AddLocationPage",true);
        }
        
        async void ExecuteNavigateToLocationGames()
        {
            await Shell.Current.GoToAsync("/LocationGamesPage", true);
        }

        private void ExecuteFilterClickedCommand()
        {
            _popupService.PushAsync(new GamesFilterPopup());
        }

        async void ExecutePinClickedCommand(ImagePin pin)
        {
            if (Preferences.ContainsKey("isLoggedIn"))
            {
                IsDetails = true;
                IsLeaderboardBusy = true;
                IsOpenGamesBusy = true;
                SelecteLocationName = pin.Name;
                SelectedLocationAddress = pin.Address;
                LoadLeaderBoard();
                IsLeaderboardBusy = false;
                LoadOpenGames();
                IsOpenGamesBusy = false;
            }
            else
            {
                await MopupService.Instance.PushAsync(new UnregisteredPopup());
            }
        }

        private async void LoadLocations()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(2000);
                var locations = await _apiService.LoDoApi.GetLocations();
                if (locations != null)
                    foreach (var l in locations)
                    {
                        GamesAndEvents.Add(new ImagePin(ExecutePinClickedCommand)
                        {
                            Id = l.Id.ToString(),
                            Icon = "pin",
                            Name = l.Name,
                            Address = l.Address.Street + "," + l.Address.StreetNumber,
                            Position = new Location(l.Latitude, l.Longitude)
                        });
                    }

                IsBusy = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async void LoadLeaderBoard()
        {
            LeaderboardUsers = new ObservableCollection<LeaderboardUserModel>();
            LeaderboardUsers.Add(new LeaderboardUserModel()
            {
                UserId = 0,
                UserIndex = 1,
                Username = "Ivan Bannyk",
            });
            LeaderboardUsers.Add(new LeaderboardUserModel()
            {
                UserId = 0,
                UserIndex = 2,
                Username = "Ivan Bannyk",
            });
            LeaderboardUsers.Add(new LeaderboardUserModel()
            {
                UserId = 0,
                UserIndex = 3,
                Username = "Ivan Bannyk",
            });
            LeaderboardUsers.Add(new LeaderboardUserModel()
            {
                UserId = 0,
                UserIndex = 4,
                Username = "Ivan Bannyk",
            });
    }
        
        private async void LoadOpenGames()
        {}
    }
}
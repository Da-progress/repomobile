using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Models;
using System.Collections.ObjectModel;

namespace LoDo.MAUI.ViewModels
{
    public partial class MyGamesPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<string> _headers = new ObservableCollection<string>();
        [ObservableProperty]
        private int _currentIndex = 1;
        [ObservableProperty]
        private bool _isUpdating = false;
        [ObservableProperty]
        private ObservableCollection<Game> _games = new ObservableCollection<Game>();
        [ObservableProperty]
        private ObservableCollection<Game> _currentGames = new ObservableCollection<Game>();

        private Command _loadGames;
        public Command LoadGamesCommand =>
            _loadGames ?? (_loadGames = new Command(ExecuteLoadGamesCommand));

        async void ExecuteLoadGamesCommand()
        {
            IsUpdating = true;
            await Task.Delay(800);
            SwitchGames();
            IsUpdating = false;
        }

        public MyGamesPageViewModel()
        {
            Headers.Add("Played");
            Headers.Add("Planned");
            Headers.Add("Open");
            Headers.Add("Confirmed");
            MockGames();
            ExecuteLoadGamesCommand();
        }

        private void MockGames()
        {
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="PLAYED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="CONFIRMED" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="OPEN" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
            Games.Add(new Game() { GameState="PLANNED" });
        }

        private void SwitchGames()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                switch (CurrentIndex)
                {
                    case 0:
                        CurrentGames.Clear();
                        foreach (var game in Games.Where(x => x.GameState.Equals("PLAYED")).ToObservableCollection())
                        {
                            CurrentGames.Add(game);
                            await Task.Delay(20);
                        }
                        break;
                    case 1:
                        CurrentGames.Clear();
                        foreach (var game in Games.Where(x => x.GameState.Equals("PLANNED")).ToObservableCollection())
                        {
                            CurrentGames.Add(game);
                            await Task.Delay(20);
                        }
                        break;
                    case 2:
                        CurrentGames.Clear();
                        foreach (var game in Games.Where(x => x.GameState.Equals("OPEN")).ToObservableCollection())
                        {
                            CurrentGames.Add(game);
                            await Task.Delay(20);
                        }
                        break;
                    case 3:
                        CurrentGames.Clear();
                        foreach (var game in Games.Where(x => x.GameState.Equals("CONFIRMED")).ToObservableCollection())
                        {
                            CurrentGames.Add(game);
                            await Task.Delay(20);
                        }
                        break;
                }
            });
        }
    }
}

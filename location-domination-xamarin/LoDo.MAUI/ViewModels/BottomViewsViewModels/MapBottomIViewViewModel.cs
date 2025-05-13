using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.ViewModels.BottomViewsViewModels
{
    public partial class MapBottomIViewViewModel : ObservableObject
    {
        private Command _navigateToLocationGames;
        public Command NavigateToLocationGamesCommand =>
            _navigateToLocationGames ?? (_navigateToLocationGames = new Command(ExecuteNavigateToLocationGamesCommand));

        [ObservableProperty]
        private bool _isUpdating = false;
        [ObservableProperty]
        private ObservableCollection<Game> _locationGames;

        async void ExecuteNavigateToLocationGamesCommand()
        {
            await Shell.Current.GoToAsync("/LocationGamesPage", true);
        }
        public MapBottomIViewViewModel()
        {
        }
    }
}

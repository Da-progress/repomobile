using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Models;
using LoDo.MAUI.Models.App;

namespace LoDo.MAUI.ViewModels;

public partial class LeaderBoardPageViewModel : ObservableObject
{
    [ObservableProperty] private LeaderboardPageUserModel _firstPlace;
    [ObservableProperty] private LeaderboardPageUserModel _secondPlace;
    [ObservableProperty] private LeaderboardPageUserModel _thirdPlace;
    [ObservableProperty] private ObservableCollection<LeaderboardPageUserModel> _users; 
    [ObservableProperty] private LeaderboardPageUserModel _mainUser; 
    [ObservableProperty] private bool _isBusy = false;
    [ObservableProperty] private bool _isFromLocation = false;
    [ObservableProperty] private string _locationName = "Location Name";
    [ObservableProperty] private bool _doesUserHasModel = true;
    
    public LeaderBoardPageViewModel()
    {
        LoadLeaderBoardData();
    }

    private async void LoadLeaderBoardData()
    {
        IsBusy = true;
        try
        {
            Users = new ObservableCollection<LeaderboardPageUserModel>();
            for (int i = 0; i < 15; i++)
            {
                Users.Add(new  LeaderboardPageUserModel()
                {
                    Rank = i + 1,
                    Score = 1000 * 15 - i,
                });
                Users.OrderByDescending( u => u.Score);
            }

            FirstPlace = Users.First(u => u.Rank == 1);
            SecondPlace = Users.First(u => u.Rank == 2);
            ThirdPlace = Users.First(u => u.Rank == 3);
            Users.Remove(FirstPlace);
            Users.Remove(SecondPlace);
            Users.Remove(ThirdPlace);
            MainUser = new LeaderboardPageUserModel()
            {
                Rank = 16,
                Score = 1000,
            };
            IsBusy = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
          IsBusy = false;
        }
    }
}
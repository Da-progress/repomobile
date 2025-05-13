using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Views.Popups;
using Mopups.Services;

namespace LoDo.MAUI.ViewModels;

public partial class SponsorshipPageViewModel : ModelBase
{
    [ObservableProperty] private ObservableCollection<string> _sponsorshipList = new();

    public ICommand CheckLocationsComamnd => new Command(OnCheckLocations); 
    
    public SponsorshipPageViewModel()
    {
        SponsorshipList = new()
        {
            "1",
            "1",
            "1",
            "1",
            "1",
            "1",
        };
    }


    private async void OnCheckLocations()
    {
        Vibrate();
        await MopupService.Instance.PushAsync(new UnregisteredPopup());
    }
    
}
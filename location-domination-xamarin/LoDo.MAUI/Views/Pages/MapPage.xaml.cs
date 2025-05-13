using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using LoDo.MAUI.ViewModels;
using LoDo.MAUI.Views.Popups.Technical;
using LoDo.MAUI.Views.Related.BottomViews;
using LoDo.MAUI.Views.Related.Controls.Map;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Platform;
using Mopups.Services;

namespace LoDo.MAUI.Views.Pages;

public partial class MapPage : ContentPage
{
    public double CellHeight { get; set; }
    public MapPage(MapPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as MapPageViewModel;
        FindMyLocation(this,EventArgs.Empty);
        await Task.Delay(2000);
        CellHeight = LeaderboardGrid.Height / 3;
    }

    private void MapPinClicked(ImagePin pin)
    {
        // Handle pin click
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
    }
    
    private async void FindMyLocation(object? sender, EventArgs e)
    {
        
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
        
            if (location != null)
            {
                var position = new Location(location.Latitude, location.Longitude);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
            }
            else
            {
                await DisplayAlert("Error", "Location not available.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to get location: " + ex.Message, "OK");
        }
    }
}
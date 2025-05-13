using LoDo.MAUI.ViewModels.BottomViewsViewModels;
using The49.Maui.BottomSheet;
using ServiceProvider = LoDo.MAUI.Services.ServiceProvider;
namespace LoDo.MAUI.Views.Related.BottomViews;

public partial class MapBottomView : BottomSheet
{
	public MapBottomView()
	{
		InitializeComponent();
		BindingContext = ServiceProvider.GetService<MapBottomIViewViewModel>();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await this.DismissAsync();
        await Shell.Current.GoToAsync("/LocationGamesPage", true);
    }
}
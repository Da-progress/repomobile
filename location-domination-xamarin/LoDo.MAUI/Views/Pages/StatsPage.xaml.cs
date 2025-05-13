using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class StatsPage : ContentPage
{
	public StatsPage(StatsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}